import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/RecenzijaPage.dart';
import 'package:eautobusmobile/pages/RedVoznjePage.dart';
import 'package:eautobusmobile/pages/korisnik/RegistracijaKorisnika.dart';
import 'package:eautobusmobile/providers/karta_provider.dart';
import 'package:eautobusmobile/providers/login_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:eautobusmobile/providers/registracija_provider.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:provider/provider.dart';
import '../../models/cjenovnik/Cjenovnik.dart';
import '../../providers/cjenovnik_provider.dart';
import '../../providers/user_provider.dart';
import '../../utils/util.dart';
import 'package:eautobusmobile/pages/InfoPage.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => CjenovnikProvider()),
        ChangeNotifierProvider(create: (_) => KorisnikProvider()),
        ChangeNotifierProvider(create: (_) => RegistracijaProvider()),
        ChangeNotifierProvider(create: (_) => RedVoznjeProvider()),
        ChangeNotifierProvider(create: (_) => KartaProvider()),
        ChangeNotifierProvider(create: (_) => LoginProvider()),
        //ChangeNotifierProvider(create: (_) =>RecomendedProvider()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          brightness: Brightness.light,
          primaryColor: Color.fromARGB(255, 183, 160, 58),
          textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                  primary: Colors.deepPurple,
                  textStyle: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic))),
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
          ),
        ),
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == CjenovnikPage.routeName) {
            return MaterialPageRoute(builder: ((context) => CjenovnikPage()));
          } else if (settings.name == RegistracijaPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => RegistracijaPage()));
          } else if (settings.name == RecenzijaPage.routeName) {
            return MaterialPageRoute(builder: ((context) => RecenzijaPage()));
          } else if (settings.name == RedVoznjePage.routeName) {
            return MaterialPageRoute(builder: ((context) => RedVoznjePage()));
          } else if (settings.name == InfoPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => InfoPage(
                      korisnikId: null,
                    )));
          } else if (settings.name == HomePage.routeName) {
            return MaterialPageRoute(builder: ((context) => HomePage()));
          }
        },
      ),
    ));

class HomePage extends StatefulWidget {
  static const String? routeName = "Home";
  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  TextEditingController _usernameController = TextEditingController();

  TextEditingController _passwordController = TextEditingController();

  late KorisnikProvider _userProvider;
  late LoginProvider _loginProvider;

  bool _hidePass = true;

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<KorisnikProvider>(context, listen: false);
    _loginProvider = Provider.of<LoginProvider>(context, listen: false);
    return Scaffold(
      backgroundColor: Colors.amber[300],
      appBar: AppBar(
        title: Text("eAutobus"),
        backgroundColor: Color.fromARGB(251, 252, 122, 1),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 200,
              decoration: BoxDecoration(),
              child: Stack(children: [
                Positioned(
                    left: 120,
                    top: 50,
                    width: 80,
                    height: 120,
                    child: Container(decoration: BoxDecoration())),
                Positioned(
                    right: 40,
                    top: 0,
                    width: 80,
                    height: 80,
                    child: Container()),
                Center(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Container(
                          margin: const EdgeInsets.all(20),
                          child: const Text(
                            "Login",
                            style: TextStyle(
                                color: Color.fromARGB(255, 255, 81, 0),
                                fontSize: 40,
                                fontWeight: FontWeight.bold),
                          )),
                      const FaIcon(
                        FontAwesomeIcons.busSimple,
                        color: Color.fromARGB(255, 255, 81, 0),
                        size: 50,
                      ),
                    ],
                  ),
                )
              ]),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                  color: Color.fromARGB(255, 255, 115, 0),
                  borderRadius: BorderRadius.circular(10),
                ),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(10),
                    decoration: BoxDecoration(
                        border: Border(
                            bottom: BorderSide(
                                color: Color.fromARGB(255, 255, 255, 255)))),
                    child: TextFormField(
                      style: TextStyle(color: Colors.white, fontSize: 18),
                      controller: _usernameController,
                      decoration: InputDecoration(
                        border: InputBorder.none,
                        labelText: "User name",
                        labelStyle: TextStyle(color: Colors.white),
                      ),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
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
                        labelStyle: TextStyle(color: Colors.white),
                        focusedBorder: UnderlineInputBorder(
                          borderSide:
                              BorderSide(color: Color.fromARGB(0, 246, 156, 2)),
                        ),
                      ),
                    ),
                  ),
                ]),
              ),
            ),
            SizedBox(
              height: 2,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
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
                              title: Text("Wrong username or password"),
                              content: Text(e.toString()),
                              actions: [
                                TextButton(
                                  child: Text("Ok"),
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
            SizedBox(
              height: 40,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                color: Color.fromARGB(255, 255, 80, 0),
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
    );
  }
}
