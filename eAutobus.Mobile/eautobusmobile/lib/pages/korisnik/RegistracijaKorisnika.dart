import 'package:eautobusmobile/pages/InfoPage.dart';
import 'package:eautobusmobile/providers/registracija_provider.dart';
import 'package:eautobusmobile/utils/util.dart';
import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';
import '../../models/korisnik/KorisnikRegistracija.dart';
import '../../models/response/error_response.dart';
import '../HomePage.dart';

class RegistracijaPage extends StatefulWidget {
  static const String routeName = "Registracija";
  const RegistracijaPage({Key? key}) : super(key: key);

  @override
  _RegistracijaState createState() => _RegistracijaState();
}

class _RegistracijaState extends State<RegistracijaPage> {
  TextStyle style = const TextStyle(fontSize: 18.0);

  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController adresaController = TextEditingController();
  TextEditingController brojTelefonaController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController dtpDatumRodjenjaController = TextEditingController();
  TextEditingController korisnickoImeController = TextEditingController();
  TextEditingController lozinkaController = TextEditingController();
  TextEditingController potvrdalozinkaController = TextEditingController();

  FocusNode focusNode = FocusNode();
  late RegistracijaProvider _registracijaProvider;
  dynamic _existUSer;
  Map? newUser = null;
  KorisnikRegistracijaRequest request = KorisnikRegistracijaRequest();

  final _formKey = GlobalKey<FormState>();
  final _obaveznoPolje = "Polje je obavezno";

  Future<void> _showDialog(String text) async {
    return showDialog<void>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Colors.grey,
          content: Text(
            text,
            style: const TextStyle(
                color: Colors.white, fontWeight: FontWeight.bold),
          ),
          actions: <Widget>[
            TextButton(
              child: const Text(
                'OK',
                style: TextStyle(color: Colors.white),
              ),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  bool _isObscure = true;
  bool _potvrda = true;

  @override
  Widget build(BuildContext context) {
    _registracijaProvider =
        Provider.of<RegistracijaProvider>(context, listen: false);

    final txtIme = Container(
      child: TextFormField(
        style: const TextStyle(color: Colors.white),
        validator: (value) {
          return value == null || value.isEmpty ? _obaveznoPolje : null;
        },
        controller: imeController,
        obscureText: false,
        decoration: InputDecoration(
            contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            labelText: "Ime",
            labelStyle: TextStyle(color: Colors.white),
            border:
                OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
      ),
    );
    final txtPrezime = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: prezimeController,
      obscureText: false,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          labelText: "Prezime",
          labelStyle: TextStyle(color: Colors.white),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtMail = TextFormField(
      style: const TextStyle(color: Colors.white),
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (!EmailValidator.validate(value)) {
          return "Neispravan format!";
        } else {
          return null;
        }
      },
      controller: emailController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          labelText: "Email",
          labelStyle: TextStyle(color: Colors.white),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtAdresaStanovanja = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: adresaController,
      obscureText: false,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          labelText: "Adresa stanovanja",
          labelStyle: TextStyle(color: Colors.white),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtBrojTelefona = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: brojTelefonaController,
      keyboardType: TextInputType.number,
      inputFormatters: <TextInputFormatter>[
        FilteringTextInputFormatter.digitsOnly
      ],
      obscureText: false,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          labelText: "Broj telefona",
          labelStyle: TextStyle(color: Colors.white),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtKorisnickoIme = TextFormField(
      style: const TextStyle(color: Colors.white),
      validator: (value) {
        return value == null || value.isEmpty ? _obaveznoPolje : null;
      },
      controller: korisnickoImeController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          labelText: "Korisnicko ime",
          labelStyle: TextStyle(color: Colors.white),
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final txtLozinka = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (value.length < 6) {
          return "Minimalna dužina 6!";
        } else if (!value.contains(RegExp(r'[0-9]')) ||
            !value.contains(RegExp(r'[a-zA-Z]'))) {
          return "Obavezno jedno slovo i broj!";
        } else {
          return null;
        }
      },
      controller: lozinkaController,
      obscureText: _isObscure,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          suffixIcon: IconButton(
              icon: Icon(
                _isObscure ? Icons.visibility : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _isObscure = !_isObscure;
                });
              }),
          labelText: "Password",
          labelStyle: TextStyle(color: Colors.white),
          border: OutlineInputBorder(
              borderRadius: BorderRadius.circular(32.0),
              borderSide:
                  BorderSide(color: Color.fromARGB(255, 255, 1, 1), width: 2))),
    );
    final txtPotvrdaPassworda = TextFormField(
      validator: (value) {
        if (value == null || value.isEmpty) {
          return _obaveznoPolje;
        } else if (value.length < 6) {
          return "Minimalna dužina 6!";
        } else if (value != lozinkaController.text) {
          return "Passwordi se ne poklapaju";
        } else {
          return null;
        }
      },
      controller: potvrdalozinkaController,
      obscureText: _potvrda,
      style: const TextStyle(color: Colors.white),
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          suffixIcon: IconButton(
              icon: Icon(
                _potvrda ? Icons.visibility : Icons.visibility_off,
              ),
              onPressed: () {
                setState(() {
                  _potvrda = !_potvrda;
                });
              }),
          labelText: "Potvrda passworda",
          labelStyle: TextStyle(color: Colors.white),
          border: OutlineInputBorder(
              borderRadius: BorderRadius.circular(32.0),
              borderSide:
                  BorderSide(color: Color.fromARGB(255, 255, 1, 1), width: 2))),
    );

    final btnOdustani = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      child: MaterialButton(
        color: Color.fromARGB(255, 255, 81, 0),
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () async {
          Navigator.of(context).pushAndRemoveUntil(
            MaterialPageRoute(
              builder: (BuildContext context) => HomePage(),
            ),
            (route) => false,
          );
        },
        child: Text("Odustani",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );
    final btnRegistrujSe = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      child: MaterialButton(
        padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        color: Color.fromARGB(255, 255, 81, 0),
        onPressed: () async {
          if (_formKey.currentState!.validate()) {
            newUser = {
              "korisnickoIme": korisnickoImeController.text,
              "ime": imeController.text,
              "prezime": prezimeController.text,
              "brojTelefona": brojTelefonaController.text,
              "email": emailController.text,
              "adresaStanovanja": adresaController.text,
              "password": lozinkaController.text,
              "potvrdaPassworda": potvrdalozinkaController.text,
            };
            Authorization.username = korisnickoImeController.text;
            Authorization.password = lozinkaController.text;
            try {
              var kreiraniUser =
                  await _registracijaProvider.registracija(newUser);
              if (kreiraniUser == null) {
                _showDialog("Korisnik vec postoji!");
              }

              CircularProgressIndicator();
              Navigator.of(context).pushAndRemoveUntil(
                MaterialPageRoute(
                    builder: (BuildContext context) => InfoPage(
                          korisnikId: kreiraniUser?.kupacID,
                        )),
                (route) => false,
              );
            } catch (e) {
              _showDialog(
                  "Nije moguce kreirati novog korisnika. Pokusajte kasnije!");
            }
          } else {
            _showDialog((_existUSer as ErrorResponse).message as String);
          }
        },
        child: Text("Registruj se",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    return Scaffold(
      backgroundColor: Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: Text(
          "Registracija korisnika",
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: Center(
        child: ListView(children: [
          Container(
            padding: EdgeInsets.fromLTRB(0, 50, 0, 0),
            color: Color.fromARGB(255, 248, 183, 86),
            child: Padding(
              padding: const EdgeInsets.all(36.0),
              child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Form(
                      key: _formKey,
                      child: Column(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            Row(
                              children: [
                                Flexible(child: txtIme),
                                const SizedBox(
                                  width: 10,
                                ),
                                Flexible(child: txtPrezime)
                              ],
                            ),
                            const SizedBox(height: 50),
                            Row(
                              children: [
                                Flexible(child: txtAdresaStanovanja),
                                const SizedBox(
                                  width: 10,
                                ),
                                Flexible(
                                  child: txtMail,
                                )
                              ],
                            ),
                            const SizedBox(height: 50),
                            Row(
                              children: [
                                Flexible(child: txtBrojTelefona),
                                const SizedBox(width: 10),
                                Flexible(child: txtKorisnickoIme),
                              ],
                            ),
                            const SizedBox(height: 50),
                            Row(
                              children: [
                                Flexible(child: txtLozinka),
                                const SizedBox(
                                  width: 10,
                                ),
                                Flexible(child: txtPotvrdaPassworda)
                              ],
                            ),
                            const SizedBox(height: 30),
                            Row(
                                crossAxisAlignment: CrossAxisAlignment.center,
                                mainAxisAlignment: MainAxisAlignment.center,
                                children: [
                                  Expanded(child: btnOdustani),
                                  const SizedBox(width: 15.0),
                                  Expanded(child: btnRegistrujSe)
                                ]),
                          ]),
                    ),
                  ]),
            ),
          ),
        ]),
      ),
    );
  }
}
