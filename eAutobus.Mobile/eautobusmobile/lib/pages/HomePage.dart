import 'package:eautobusmobile/pages/InfoPage.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:provider/provider.dart';

import '../providers/login_provider.dart';
import '../utils/util.dart';
import 'korisnik/RegistracijaKorisnika.dart';

class HomePage extends StatefulWidget {
  static const String? routeName = "HomePage";

  HomePage({Key? key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  TextEditingController _usernameController = TextEditingController();

  TextEditingController _passwordController = TextEditingController();

  late LoginProvider _loginProvider;

  bool _hidePass = true;

  @override
  Widget build(BuildContext context) {
    _loginProvider = Provider.of<LoginProvider>(context, listen: false);
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        title: const Text("eAutobus"),
        backgroundColor: const Color.fromARGB(251, 252, 122, 1),
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.fromLTRB(20, 50, 20, 0),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text(
                    "Login",
                    style: TextStyle(
                        color: Color.fromARGB(255, 255, 102, 0),
                        fontSize: 30,
                        fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(width: 20),
                  const FaIcon(
                    FontAwesomeIcons.busSimple,
                    color: Color.fromARGB(255, 255, 81, 0),
                    size: 50,
                  ),
                ],
              ),
              const SizedBox(height: 40),
              Padding(
                padding: const EdgeInsets.all(40),
                child: Container(
                  decoration: BoxDecoration(
                    color: const Color.fromARGB(255, 255, 115, 0),
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: Column(children: [
                    Container(
                      padding: const EdgeInsets.all(10),
                      decoration: const BoxDecoration(
                          border: Border(
                              bottom: BorderSide(
                                  color: Color.fromARGB(255, 255, 255, 255)))),
                      child: TextFormField(
                        style:
                            const TextStyle(color: Colors.white, fontSize: 18),
                        controller: _usernameController,
                        decoration: const InputDecoration(
                          border: InputBorder.none,
                          labelText: "User name",
                          labelStyle: TextStyle(color: Colors.white),
                        ),
                      ),
                    ),
                    Container(
                      padding: const EdgeInsets.all(8),
                      child: TextField(
                        style: const TextStyle(color: Colors.white),
                        controller: _passwordController,
                        obscureText: _hidePass,
                        decoration: InputDecoration(
                          border: InputBorder.none,
                          labelText: 'Password',
                          suffixIcon: IconButton(
                              icon: Icon(
                                _hidePass
                                    ? Icons.visibility
                                    : Icons.visibility_off,
                                color: Colors.white,
                              ),
                              onPressed: () {
                                setState(() {
                                  _hidePass = !_hidePass;
                                });
                              }),
                          labelStyle: const TextStyle(color: Colors.white),
                          focusedBorder: const UnderlineInputBorder(
                            borderSide: BorderSide(
                                color: Color.fromARGB(0, 246, 156, 2)),
                          ),
                        ),
                      ),
                    ),
                  ]),
                ),
              ),
              Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(40, 0, 40, 0),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    color: Color.fromARGB(255, 255, 80, 0)),
                child: InkWell(
                  onTap: () async {
                    try {
                      Authorization.username = _usernameController.text;
                      Authorization.password = _passwordController.text;
                      var user = await _loginProvider.prijava();
                      Navigator.of(context).push(
                        MaterialPageRoute(
                            builder: (ctx) =>
                                InfoPage(korisnikId: user?.korisnikId)),
                      );
                    } catch (e) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Wrong username or password"),
                                content: Text(e.toString()),
                                actions: [
                                  TextButton(
                                    child: const Text("Ok"),
                                    onPressed: () => Navigator.pop(context),
                                  )
                                ],
                              ));
                    }
                  },
                  child: const Center(
                      child: Text("Login",
                          style: TextStyle(color: Colors.white, fontSize: 15))),
                ),
              ),
              const SizedBox(
                height: 40,
              ),
              Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(40, 0, 40, 0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  color: const Color.fromARGB(255, 255, 80, 0),
                ),
                child: InkWell(
                  child: const Center(
                      child: Text(
                    "Don't have account? Create one!",
                    style: TextStyle(color: Colors.white, fontSize: 15),
                  )),
                  onTap: () async {
                    Navigator.pushNamed(context, RegistracijaPage.routeName);
                  },
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
