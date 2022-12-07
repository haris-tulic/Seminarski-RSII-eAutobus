import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/korisnik/RegistracijaKorisnika.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../models/cjenovnik/Cjenovnik.dart';
import '../../providers/cjenovnik_provider.dart';
import '../../providers/user_provider.dart';
import '../../utils/util.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => CjenovnikProvider()),
        ChangeNotifierProvider(create: (_) => KorisnikProvider()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          // Define the default brightness and colors.
          brightness: Brightness.light,
          primaryColor: Color.fromARGB(255, 183, 160, 58),
          textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                  primary: Colors.deepPurple,
                  textStyle: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic))),

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
          ),
        ),
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == CjenovnikPage.routeName) {
            return MaterialPageRoute(builder: ((context) => CjenovnikPage()));
            // } else if (settings.name == CartScreen.routeName) {
            //   return MaterialPageRoute(builder: ((context) => CartScreen()));
            // }

            // var uri = Uri.parse(settings.name!);
            // if (uri.pathSegments.length == 2 &&
            //     "/${uri.pathSegments.first}" == ProductDetailsScreen.routeName) {
            //   var id = uri.pathSegments[1];
            //   return MaterialPageRoute(
            //       builder: (context) => ProductDetailsScreen(id));
          }
        },
      ),
    ));

class HomePage extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late KorisnikProvider _userProvider;

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<KorisnikProvider>(context, listen: false);

    return Scaffold(
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
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container(decoration: BoxDecoration())),
                Positioned(
                    right: 40,
                    top: 0,
                    width: 80,
                    height: 80,
                    child: Container()),
                Container(
                  child: Center(
                      child: Text(
                    "Login",
                    style: TextStyle(
                        color: Colors.orange,
                        fontSize: 40,
                        fontWeight: FontWeight.bold),
                  )),
                )
              ]),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "User name",
                          hintStyle: TextStyle(
                              color: Color.fromARGB(255, 65, 65, 65))),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    child: TextField(
                      controller: _passwordController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Password",
                          hintStyle: TextStyle(
                              color: Color.fromARGB(255, 65, 65, 65))),
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
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 241, 110, 3),
                  Color.fromARGB(225, 248, 211, 1)
                ]),
              ),
              child: InkWell(
                onTap: () async {
                  try {
                    Authorization.username = _usernameController.text;
                    Authorization.password = _passwordController.text;

                    await _userProvider.get();

                    Navigator.pushNamed(context, CjenovnikPage.routeName);
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
                child: Center(child: Text("Login")),
              ),
            ),
            SizedBox(
              height: 40,
            ),
            Text("Forgot password?"),
            SizedBox(
              height: 40,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 241, 110, 3),
                  Color.fromARGB(225, 248, 211, 1)
                ]),
              ),
              child: InkWell(
                child: Center(child: Text("Don't have account? Create one!")),
                //onTap:() async {Navigator.pushNamed(context, Registracija.name)},
              ),
            )
          ],
        ),
      ),
    );
  }
}
