// ignore_for_file: use_build_context_synchronously

import 'dart:convert';

import 'package:eautobusmobile/models/cjenovnik/Cjenovnik.dart';
import 'package:eautobusmobile/models/karta/TipKarte.dart';
import 'package:eautobusmobile/models/karta/VrstaKarte.dart';
import 'package:eautobusmobile/models/korisnik/Korisnik.dart';
import 'package:eautobusmobile/models/redvoznje/Stanica.dart';
import 'package:eautobusmobile/providers/cjenovnik_provider.dart';
import 'package:eautobusmobile/providers/karta_provider.dart';
import 'package:eautobusmobile/providers/stanica_provider.dart';
import 'package:eautobusmobile/providers/tipkarte_provider.dart';
import 'package:eautobusmobile/providers/vrstakarte_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';
import 'package:http/http.dart' as http;
import '../helper/StripeKey.dart';

enum Smjer { jedan, dva }

List<String> nacinPlacanja = ["Preuzećem", "Online"];
Smjer _odabrani = Smjer.jedan;
String _pravac = "";

class RezervacijaKarte extends StatefulWidget {
  static const String routname = "Karta";
  final Korisnik? korisnik;
  const RezervacijaKarte({Key? key, required this.korisnik}) : super(key: key);

  @override
  State<RezervacijaKarte> createState() => _RezervacijaKarteState();
}

class _RezervacijaKarteState extends State<RezervacijaKarte> {
  final _formkey = GlobalKey<FormState>();
  final _obaveznoPolje = "Polje je obavezno";
  Map<String, dynamic>? paymentIntent;
  TextEditingController _datumPolaska = TextEditingController();
  TextEditingController _datumPovratka = TextEditingController();

  TextEditingController _cijenaPrikaz = TextEditingController();

  StanicaProvider? _stanicaProvider = null;
  TipKarteProvider? _tipKarteProvider = null;
  VrstaKarteProvider? _vrstaKarteProvider = null;
  CjenovnikProvider? _cjenovnikProvider = null;
  KartaProvider? _kartaProvider = null;
  int? stanicaOd = null;
  int? stanicaDo = null;
  int? _tipKarteS = null;
  int? _vrstaKarteS = null;
  List<Stanica>? stanicaOD = [];
  List<Stanica>? stanicaDO = [];
  int? _cijenaKarte = 0;

  List<TipKarte>? tipKarte = [];
  List<VrstaKarte>? vrstaKarte = [];
  Cjenovnik? request = null;
  DateTime _datumPOOD = DateTime.now();
  Map? kupipreuzecem;
  bool isEnabledRadio = true;
  String? descBuy;

  @override
  void initState() {
    super.initState();
    _stanicaProvider = context.read<StanicaProvider>();
    _tipKarteProvider = context.read<TipKarteProvider>();
    _vrstaKarteProvider = context.read<VrstaKarteProvider>();
    _cjenovnikProvider = context.read<CjenovnikProvider>();
    _kartaProvider = context.read<KartaProvider>();
    loadStanice();
    loadTipKarte();
    loadVrstaKarte();
  }

  Future loadStanice() async {
    var tempstanica = await _stanicaProvider?.get();

    setState(() {
      stanicaOD = tempstanica;
      stanicaDO = tempstanica;
      stanicaOd = stanicaOD?[0].stanicaID;
      stanicaDo = stanicaDO?[1].stanicaID;
    });
  }

  Future loadTipKarte() async {
    var tempTipKarte = await _tipKarteProvider?.get();
    setState(() {
      tipKarte = tempTipKarte;
    });
  }

  Future loadVrstaKarte() async {
    var tempVrstaKarte = await _vrstaKarteProvider?.get();
    setState(() {
      vrstaKarte = tempVrstaKarte;
    });
  }

  Future loadCjenovnik() async {
    Map cjenovnikPretraga = {
      "tipKarteID": _tipKarteS,
      "vrstaKarteID": _vrstaKarteS,
      "polazisteID": stanicaOd,
      "odredisteID": stanicaDo,
    };
    var tempcjenovnik = await _cjenovnikProvider?.get(cjenovnikPretraga);
    setState(() {
      if (tempcjenovnik!.isNotEmpty) {
        _cijenaKarte = tempcjenovnik[0].cijena;
        _cijenaPrikaz.text = tempcjenovnik[0].cijenaPrikaz!;
        if (_pravac == "U oba pravca" &&
            _odabrani == Smjer.dva &&
            tempcjenovnik[0].vrstaKarte == "Dnevna") {
          _cijenaKarte = (_cijenaKarte! * 1.67).toInt();
          _cijenaPrikaz.text = "${_cijenaKarte.toString()} KM";
        }
      } else {
        _showDialog(
            "Cijena za datu kartu ne moze biti pronadjena. Molimo pogledajte cjenovnik.",
            null);
        _cijenaPrikaz.text = "0 KM";
      }
    });
  }

  void _selectDate(BuildContext context, String datumS) async {
    final DateTime? _odabraniDatum = await showDatePicker(
      context: context,
      initialDate: _datumPOOD,
      firstDate: datumS == "Datum povratka" ? _datumPOOD : DateTime.now(),
      lastDate: DateTime(2035),
      cancelText: "",
    );
    setState(() {
      if (_odabraniDatum != null && _odabraniDatum != _datumPOOD) {
        _datumPOOD = _odabraniDatum!;
        if (datumS == "Datum polaska") {
          _datumPolaska.text = "${_datumPOOD.toLocal()}".substring(0, 10);
        } else if (datumS == "Datum povratka") {
          _datumPovratka.text = "${_datumPOOD.toLocal()}".substring(0, 10);
        }
      } else {
        _datumPovratka.text = "${_datumPOOD.toLocal()}".substring(0, 10);
      }
      if (_datumPolaska.text != _datumPovratka.text) {
        _odabrani = Smjer.dva;
        _pravac = "U oba pravca";
        isEnabledRadio = false;
      } else {
        _odabrani = Smjer.jedan;
        _pravac = "U jednom pravcu";
        isEnabledRadio = true;
      }
    });
  }

  void _enableRadioButtons(int vrstaKarteID) async {
    var vrstaKarte = await _vrstaKarteProvider?.getById(vrstaKarteID);
    setState(() {
      if (vrstaKarte?.naziv != "Dnevna") {
        isEnabledRadio = false;
        if (vrstaKarte?.naziv == "Mjesečna") {
          _datumPovratka.text =
              "${_datumPOOD.toLocal().add(const Duration(days: 31))}"
                  .substring(0, 10);
        } else {
          _datumPovratka.text =
              "${_datumPOOD.toLocal().add(const Duration(days: 365))}"
                  .substring(0, 10);
        }
        _odabrani = Smjer.dva;
        _pravac = "U oba pravca";
      } else {
        if (_datumPolaska.text == _datumPovratka.text) {
          isEnabledRadio = true;
        }
      }
    });
  }

  void _showDialog(String poruka, Object? e) {
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        backgroundColor: Colors.orangeAccent,
        title: Text(
          poruka,
          style:
              const TextStyle(color: Colors.white, fontStyle: FontStyle.italic),
        ),
        content: Text(e == null ? " " : e.toString()),
        actions: [
          TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text("Ok", style: TextStyle(color: Colors.white))),
        ],
      ),
    );
  }

  void showSnackBar(BuildContext context, String message) {
    final snackBar = SnackBar(
      content: Text(message),
    );
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text("Kupovina karte"),
        ),
        body: SingleChildScrollView(
          padding: const EdgeInsets.fromLTRB(10, 50, 10, 35),
          child: Form(
            key: _formkey,
            child: Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    width: 500,
                    alignment: Alignment.center,
                    color: Colors.orange[500],
                    child: DropdownButtonFormField(
                        dropdownColor: Colors.orange[300],
                        style: const TextStyle(color: Colors.white),
                        decoration: const InputDecoration(
                          labelText: "Odaberite stanicu polaska",
                          labelStyle: TextStyle(
                              color: Colors.white, fontWeight: FontWeight.bold),
                          border: OutlineInputBorder(),
                        ),
                        isDense: true,
                        validator: (value) {
                          return value == null ? _obaveznoPolje : null;
                        },
                        value: stanicaOd != null ? stanicaOd : null,
                        items: [
                          for (final stanicaod in stanicaOD!)
                            DropdownMenuItem(
                              value: stanicaod.stanicaID,
                              child: Row(
                                children: [
                                  Text("${stanicaod.nazivLokacijestanice}"),
                                ],
                              ),
                            ),
                        ],
                        onChanged: (value) {
                          setState(() {
                            stanicaOd = value as int;
                          });
                        }),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Container(
                    width: 500,
                    color: Colors.orange[500],
                    alignment: Alignment.center,
                    child: DropdownButtonFormField(
                        dropdownColor: Colors.orange[300],
                        isDense: true,
                        style: const TextStyle(color: Colors.white),
                        decoration: const InputDecoration(
                          labelText: "Odaberite stanicu dolaska",
                          labelStyle: TextStyle(
                              color: Colors.white, fontWeight: FontWeight.bold),
                          border: OutlineInputBorder(),
                        ),
                        validator: (value) {
                          return value == null ? _obaveznoPolje : null;
                        },
                        value: stanicaDo != null ? stanicaDo : null,
                        items: [
                          for (final stanicado in stanicaDO!)
                            DropdownMenuItem(
                                value: stanicado.stanicaID,
                                child: Row(
                                  children: [
                                    Text("${stanicado.nazivLokacijestanice}"),
                                  ],
                                ))
                        ],
                        onChanged: (value) {
                          setState(() {
                            stanicaDo = value as int;
                          });
                        }),
                  ),
                  const SizedBox(height: 20),
                  Container(
                    width: 300,
                    decoration: BoxDecoration(
                      border: Border.all(color: Colors.orange),
                    ),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        RadioListTile(
                            selectedTileColor: Colors.orange[400],
                            title: const Text(
                              "U jednom pravcu",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold),
                            ),
                            value: Smjer.jedan,
                            groupValue: _odabrani,
                            onChanged: !isEnabledRadio
                                ? null
                                : (value) {
                                    setState(() {
                                      _odabrani = value as Smjer;
                                      _pravac = "U jednom pravcu";
                                      isEnabledRadio = true;
                                    });
                                  }),
                        const SizedBox(height: 10),
                        RadioListTile(
                            title: const Text(
                              "U oba pravca",
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold),
                            ),
                            value: Smjer.dva,
                            groupValue: _odabrani,
                            onChanged: (value) {
                              setState(() {
                                _odabrani = value as Smjer;
                                _pravac = "U oba pravca";
                              });
                            }),
                      ],
                    ),
                  ),
                  const SizedBox(height: 20),
                  Container(
                    alignment: Alignment.center,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Flexible(
                          child: Container(
                            width: 200,
                            color: Colors.orange[500],
                            alignment: Alignment.center,
                            child: TextFormField(
                              decoration: InputDecoration(
                                labelText: "Datum izdavanja karte",
                                //contentPadding: const EdgeInsets.all(20),
                                labelStyle: const TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold),
                                border: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(0)),
                              ),
                              validator: (value) {
                                return (value == null || value.isEmpty)
                                    ? _obaveznoPolje
                                    : null;
                              },
                              controller: _datumPolaska,
                              obscureText: false,
                              style: const TextStyle(color: Colors.white),
                              onTap: () {
                                _selectDate(context, "Datum polaska");
                              },
                            ),
                          ),
                        ),
                        const SizedBox(width: 30),
                        Flexible(
                          child: Container(
                            width: 200,
                            color: Colors.orange[500],
                            alignment: Alignment.center,
                            child: TextFormField(
                              validator: (value) {
                                return (value == null || value.isEmpty)
                                    ? _obaveznoPolje
                                    : null;
                              },
                              decoration: InputDecoration(
                                labelText: "Datum vazenja karte",
                                contentPadding: const EdgeInsets.all(20),
                                labelStyle: const TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold),
                                border: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(0)),
                              ),
                              controller: _datumPovratka,
                              obscureText: false,
                              style: const TextStyle(color: Colors.white),
                              onTap: () {
                                _selectDate(context, "Datum povratka");
                              },
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 30),
                  Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                    Flexible(
                      child: Container(
                        width: 200,
                        color: Colors.orange[500],
                        child: DropdownButtonFormField(
                            isDense: true,
                            dropdownColor: Colors.orange[300],
                            style: const TextStyle(color: Colors.white),
                            decoration: const InputDecoration(
                              labelText: "Odaberite tip karte",
                              labelStyle: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold),
                              border: OutlineInputBorder(),
                            ),
                            validator: (value) {
                              return value == null ? _obaveznoPolje : null;
                            },
                            value: _tipKarteS != null ? _tipKarteS : null,
                            items: [
                              for (final kartat in tipKarte!)
                                DropdownMenuItem(
                                    value: kartat.tipKarteID,
                                    child: Row(
                                      children: [Text("${kartat.naziv}")],
                                    ))
                            ],
                            onChanged: (value) {
                              setState(() {
                                _tipKarteS = value as int;
                              });
                            }),
                      ),
                    ),
                    const SizedBox(width: 30),
                    Flexible(
                      child: Container(
                        width: 200,
                        color: Colors.orange[500],
                        child: DropdownButtonFormField(
                            isDense: true,
                            dropdownColor: Colors.orange[300],
                            style: const TextStyle(color: Colors.white),
                            decoration: const InputDecoration(
                              labelText: "Odaberite vrstu karte",
                              labelStyle: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold),
                              border: OutlineInputBorder(),
                            ),
                            validator: (value) {
                              return value == null ? _obaveznoPolje : null;
                            },
                            value: _vrstaKarteS != null ? _vrstaKarteS : null,
                            items: [
                              for (final kartav in vrstaKarte!)
                                DropdownMenuItem(
                                    value: kartav.vrstaKarteID,
                                    child: Row(
                                      children: [Text("${kartav.naziv}")],
                                    ))
                            ],
                            onChanged: (value) {
                              setState(() {
                                _vrstaKarteS = value as int;
                                _enableRadioButtons(_vrstaKarteS!);
                              });
                            }),
                      ),
                    ),
                  ]),
                  const SizedBox(height: 30),
                  Container(
                    width: 200,
                    color: Colors.orange[500],
                    child: TextFormField(
                      controller: _cijenaPrikaz,
                      validator: (value) {
                        return (value == null || value.isEmpty)
                            ? _obaveznoPolje
                            : null;
                      },
                      obscureText: false,
                      decoration: InputDecoration(
                        labelText: "Cijena",
                        labelStyle: const TextStyle(
                            color: Colors.white, fontWeight: FontWeight.bold),
                        border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(0)),
                      ),
                      style: const TextStyle(color: Colors.white),
                      readOnly: true,
                      onTap: () {
                        setState(() {
                          loadCjenovnik();
                        });
                      },
                    ),
                  ),
                  const Text(
                    "*Klikom na polje cijena, prikazujete cijenu za odabranu kartu",
                    style: TextStyle(
                        color: Colors.red,
                        fontSize: 12,
                        fontStyle: FontStyle.italic),
                  ),
                  const SizedBox(height: 30),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Material(
                        elevation: 5.0,
                        borderRadius: BorderRadius.circular(30),
                        child: MaterialButton(
                          color: const Color.fromARGB(255, 255, 81, 0),
                          padding:
                              const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                          onPressed: () async {
                            if (_formkey.currentState!.validate()) {
                              setState(() {
                                kupipreuzecem = {
                                  "tipKarteID": _tipKarteS,
                                  "vrstaKarteID": _vrstaKarteS,
                                  "kupacID": widget.korisnik?.kupacID,
                                  "datumVadjenjaKarte": _datumPolaska.text,
                                  "datumVazenjaKarte": _datumPovratka.text,
                                  "odredisteID": stanicaDo,
                                  "polazisteID": stanicaOd,
                                  "pravac": true,
                                  "cijena": _cijenaKarte?.toDouble(),
                                  "nacinPlacanja": nacinPlacanja[0],
                                  "pravacS": _pravac,
                                  "ime": widget.korisnik?.ime,
                                  "prezime": widget.korisnik?.prezime,
                                  "email": widget.korisnik?.email,
                                  "brojTelefona": widget.korisnik?.brojTelefona,
                                  "adresaStanovanja":
                                      widget.korisnik?.adresaStanovanja,
                                  "korisnickoIme":
                                      widget.korisnik?.korisnickoIme,
                                };
                              });
                              try {
                                await _kartaProvider?.insert(kupipreuzecem);
                                CircularProgressIndicator(
                                    backgroundColor: Colors.orange[800]);
                                showSnackBar(context,
                                    "Karta uspjesno kupljena. Mozete je preuzeti na salteru!");
                              } catch (e) {
                                showSnackBar(context,
                                    "Zao nam je, ali vasa kupovina nije uspjela. Pokusajte kasnije");
                              }
                            }
                          },
                          child: const Text(
                            "Kupi kartu",
                            textAlign: TextAlign.center,
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                      const SizedBox(width: 30),
                      Material(
                        elevation: 5.0,
                        borderRadius: BorderRadius.circular(30),
                        child: MaterialButton(
                          color: const Color.fromARGB(255, 255, 81, 0),
                          padding:
                              const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                          onPressed: () async {
                            if (_formkey.currentState!.validate()) {
                              setState(() {
                                kupipreuzecem = {
                                  "tipKarteID": _tipKarteS,
                                  "vrstaKarteID": _vrstaKarteS,
                                  "kupacID": widget.korisnik?.kupacID,
                                  "datumVadjenjaKarte": _datumPolaska.text,
                                  "datumVazenjaKarte": _datumPovratka.text,
                                  "odredisteID": stanicaDo,
                                  "polazisteID": stanicaOd,
                                  "pravac": true,
                                  "cijena": _cijenaKarte?.toDouble(),
                                  "nacinPlacanja": nacinPlacanja[1],
                                  "pravacS": _pravac,
                                  "ime": widget.korisnik?.ime,
                                  "prezime": widget.korisnik?.prezime,
                                  "email": widget.korisnik?.email,
                                  "brojTelefona": widget.korisnik?.brojTelefona,
                                  "adresaStanovanja":
                                      widget.korisnik?.adresaStanovanja,
                                  "korisnickoIme":
                                      widget.korisnik?.korisnickoIme,
                                };
                              });
                              try {
                                await kupiOnline(_cijenaKarte?.toString());
                                await _kartaProvider?.insert(kupipreuzecem);
                              } catch (e) {
                                _showDialog(
                                    "Kartu nije moguce kupiti. Molimo pokusajte kasnije",
                                    e);
                              }
                            }
                          },
                          child: const Text(
                            "Online kupovina",
                            textAlign: TextAlign.center,
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ));
  }

  createPaymentIntent(dynamic amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': calculateAmount(amount),
        'currency': currency,
        'description': "Placeno",
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
        Uri.parse('https://api.stripe.com/v1/payment_intents'),
        headers: {
          'Authorization': 'Bearer $secretkey',
          'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: body,
      );
      return jsonDecode(response.body);
    } catch (err) {
      showDialog(
        context: context,
        builder: (_) => const AlertDialog(
          content: Text("Cancelled "),
        ),
      );
    }
  }

  Future<void> kupiOnline(dynamic cijenaKarte) async {
    try {
      paymentIntent = await createPaymentIntent(cijenaKarte, 'BAM');
      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret: paymentIntent!['client_secret'],
                  // applePay: const PaymentSheetApplePay(merchantCountryCode: '+92',),
                  // googlePay: const PaymentSheetGooglePay(testEnv: true, currencyCode: "US", merchantCountryCode: "+92"),
                  style: ThemeMode.dark,
                  merchantDisplayName: 'Adnan'))
          .then((value) {});

      ///now finally display payment sheeet
      displayPaymentSheet();
    } catch (e, s) {
      print('exception:$e$s');
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((value) {
        showDialog(
            context: context,
            builder: (_) => const AlertDialog(
                  content: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Row(
                        children: [
                          Icon(
                            Icons.check_circle,
                            color: Colors.green,
                          ),
                          Text("Payment Successfull"),
                        ],
                      ),
                    ],
                  ),
                ));
        // ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text("paid successfully")));

        paymentIntent = null;
      }).onError((error, stackTrace) {
        showDialog(
          context: context,
          builder: (_) => const AlertDialog(
            content: Text("Error "),
          ),
        );
      });
    } on StripeException catch (e) {
      showDialog(
        context: context,
        builder: (_) => const AlertDialog(
          content: Text("Cancelled "),
        ),
      );
    } catch (e) {
      showDialog(
        context: context,
        builder: (_) => const AlertDialog(
          content: Text("Cancelled "),
        ),
      );
    }
  }
  //  Future<Map<String, dynamic>>

  calculateAmount(String amount) {
    final calculatedAmout = (int.parse(amount)) * 100;
    return calculatedAmout.toString();
  }
}
