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
import 'package:provider/provider.dart';

enum Smjer { jedan, dva }

List<String> nacinPlacanja = ["Preuzecem", "Karticno"];
Smjer _odabrani = Smjer.jedan;
String _pravac = "";

class RezervacijaKarte extends StatefulWidget {
  static const String routname = "Karta";
  final Korisnik? korisnik;
  RezervacijaKarte({Key? key, required this.korisnik}) : super(key: key);

  @override
  State<RezervacijaKarte> createState() => _RezervacijaKarteState();
}

class _RezervacijaKarteState extends State<RezervacijaKarte> {
  final _formkey = GlobalKey<FormState>();
  TextEditingController _datumPolaska = TextEditingController();
  TextEditingController _datumPovratka = TextEditingController();
  TextEditingController _stanicaDO = TextEditingController();
  TextEditingController _stanicaOD = TextEditingController();
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
      if (tempcjenovnik != null) {
        _cijenaKarte = tempcjenovnik[0].cijena;
        _cijenaPrikaz.text = tempcjenovnik[0].cijenaPrikaz!;
      }
    });
  }

  void _selectDate(BuildContext context, String datumS) async {
    final DateTime? _odabraniDatum = await showDatePicker(
      context: context,
      initialDate: _datumPOOD,
      firstDate: DateTime.now(),
      lastDate: DateTime(2035),
    );
    setState(() {
      if (_odabraniDatum != null || _odabraniDatum != _datumPOOD) {
        _datumPOOD = _odabraniDatum!;
        if (datumS == "Datum polaska") {
          _datumPolaska.text = "${_datumPOOD.toLocal()}".substring(0, 10);
        } else if (datumS == "Datum povratka") {
          _datumPovratka.text = "${_datumPOOD.toLocal()}".substring(0, 10);
        }
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
        _pravac = "U oba smjera";
      } else {
        isEnabledRadio = true;
      }
    });
  }

  void _showDialog(String poruka, Object? e) {
    showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
        backgroundColor: Colors.grey,
        title: Text(
          poruka,
          style: TextStyle(color: Colors.white, fontStyle: FontStyle.italic),
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

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color.fromARGB(255, 248, 183, 86),
        appBar: AppBar(
          backgroundColor: Colors.amber[800],
          title: const Text("Kupovina karte"),
        ),
        body: SingleChildScrollView(
          padding: EdgeInsets.fromLTRB(0, 50, 0, 0),
          child: Form(
            child: Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Container(
                    width: 500,
                    alignment: Alignment.center,
                    child: DropdownButtonFormField(
                        dropdownColor: Colors.grey,
                        style: const TextStyle(color: Colors.white),
                        decoration: const InputDecoration(
                          labelText: "Odaberite stanicu polaska",
                          labelStyle: TextStyle(color: Colors.white),
                          border: OutlineInputBorder(),
                        ),
                        isDense: true,
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
                    alignment: Alignment.center,
                    child: DropdownButtonFormField(
                        dropdownColor: Colors.grey,
                        isDense: true,
                        style: const TextStyle(color: Colors.white),
                        decoration: const InputDecoration(
                          labelText: "Odaberite stanicu dolaska",
                          labelStyle: TextStyle(color: Colors.white),
                          border: OutlineInputBorder(),
                        ),
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
                    width: 500,
                    alignment: Alignment.center,
                    child: RadioListTile(
                        selectedTileColor: Colors.white,
                        title: const Text(
                          "U jednom pravcu",
                          style: TextStyle(color: Colors.white),
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
                  ),
                  const SizedBox(height: 10),
                  Container(
                    width: 500,
                    alignment: Alignment.center,
                    child: RadioListTile(
                        title: const Text(
                          "U oba pravca",
                          style: TextStyle(
                            color: Colors.white,
                          ),
                        ),
                        value: Smjer.dva,
                        groupValue: _odabrani,
                        onChanged: (value) {
                          setState(() {
                            _odabrani = value as Smjer;
                            _pravac = "U oba pravca";
                          });
                        }),
                  ),
                  const SizedBox(height: 20),
                  Container(
                    alignment: Alignment.center,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        Container(
                          width: 200,
                          alignment: Alignment.center,
                          child: TextFormField(
                            decoration: InputDecoration(
                              labelText: "Datum izdavanja karte",
                              contentPadding: const EdgeInsets.all(20),
                              labelStyle: const TextStyle(color: Colors.white),
                              border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(20)),
                            ),
                            controller: _datumPolaska,
                            obscureText: false,
                            style: const TextStyle(color: Colors.white),
                            onTap: () {
                              _selectDate(context, "Datum polaska");
                            },
                          ),
                        ),
                        const SizedBox(width: 30),
                        Container(
                          width: 200,
                          alignment: Alignment.center,
                          child: TextFormField(
                            decoration: InputDecoration(
                              labelText: "Datum vazenja karte",
                              contentPadding: const EdgeInsets.all(20),
                              labelStyle: const TextStyle(color: Colors.white),
                              border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(20)),
                            ),
                            controller: _datumPovratka,
                            obscureText: false,
                            style: const TextStyle(color: Colors.white),
                            onTap: () {
                              _selectDate(context, "Datum povratka");
                            },
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 30),
                  Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                    Container(
                      width: 200,
                      child: DropdownButtonFormField(
                          isDense: true,
                          dropdownColor: Colors.grey,
                          style: const TextStyle(color: Colors.white),
                          decoration: const InputDecoration(
                            labelText: "Odaberite tip karte",
                            labelStyle: TextStyle(color: Colors.white),
                            border: OutlineInputBorder(),
                          ),
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
                    const SizedBox(width: 30),
                    Container(
                      width: 200,
                      child: DropdownButtonFormField(
                          isDense: true,
                          dropdownColor: Colors.grey,
                          style: const TextStyle(color: Colors.white),
                          decoration: const InputDecoration(
                            labelText: "Odaberite vrstu karte",
                            labelStyle: TextStyle(color: Colors.white),
                            border: OutlineInputBorder(),
                          ),
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
                  ]),
                  const SizedBox(height: 30),
                  Container(
                    width: 200,
                    child: TextFormField(
                      controller: _cijenaPrikaz,
                      decoration: InputDecoration(
                        labelText: "Cijena",
                        helperText: "*Kliknite za prikaz cijene",
                        helperStyle: TextStyle(color: Colors.red),
                        labelStyle: const TextStyle(color: Colors.white),
                        border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(20)),
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
                  const SizedBox(height: 30),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Material(
                        elevation: 5.0,
                        borderRadius: BorderRadius.circular(30),
                        child: MaterialButton(
                          child: Text(
                            "Kupi kartu",
                            textAlign: TextAlign.center,
                            style: TextStyle(color: Colors.white),
                          ),
                          color: Color.fromARGB(255, 255, 81, 0),
                          padding:
                              const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                          onPressed: () async {
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
                                "korisnickoIme": widget.korisnik?.korisnickoIme,
                              };
                            });
                            try {
                              await _kartaProvider?.insert(kupipreuzecem);
                              _showDialog(
                                  "Kartu mozete preuzeti na salteru!", null);
                              Navigator.pop(context, true);
                            } catch (e) {
                              _showDialog(
                                  "Kartu nije moguce kupiti. Molimo pokusajte kasnije",
                                  e);
                            }
                          },
                        ),
                      ),
                      const SizedBox(width: 30),
                      Material(
                        elevation: 5.0,
                        borderRadius: BorderRadius.circular(30),
                        child: MaterialButton(
                          child: Text(
                            "Online kupovina",
                            textAlign: TextAlign.center,
                            style: TextStyle(color: Colors.white),
                          ),
                          color: Color.fromARGB(255, 255, 81, 0),
                          padding:
                              const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                          onPressed: () async {
                            Map kupipreuzecem = {};
                            try {
                              // await _kartaProvider?.insert(kupipreuzecem);
                            } catch (e) {
                              _showDialog(
                                  "Kartu nije moguce kupiti. Molimo pokusajte kasnije",
                                  e);
                            }
                          },
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
}
