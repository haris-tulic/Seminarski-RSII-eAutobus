import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/RecenzijaPage.dart';
import 'package:eautobusmobile/pages/RedVoznjePage.dart';
import 'package:eautobusmobile/pages/korisnik/RegistracijaKorisnika.dart';
import 'package:eautobusmobile/providers/karta_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:eautobusmobile/providers/registracija_provider.dart';
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
        ChangeNotifierProvider(create: (_) => RegistracijaProvider()),
        ChangeNotifierProvider(create: (_) => RedVoznjeProvider()),
        ChangeNotifierProvider(create: (_) => KartaProvider()),
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
                onTap: () async {
                  //Navigator.pushNamed(context, RegistracijaPage.routename);
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}

// class HomePage extends StatefulWidget {
//   @override
//   _LoginPageState createState() => _LoginPageState();
// }

// class _LoginPageState extends State<HomePage> {
//   final _formKey = GlobalKey<FormState>();
//   String? _username = " ";
//   String? _password = " ";
//   bool _obscureText = true;
//   late KorisnikProvider _userProvider;

//   void _toggleObscureText() {
//     setState(() {
//       _obscureText = !_obscureText;
//     });
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       appBar: AppBar(
//         title: Text('Login'),
//       ),
//       body: Container(
//         padding: EdgeInsets.all(20.0),
//         child: Form(
//           key: _formKey,
//           child: Column(
//             children: [
//               TextFormField(
//                 decoration: InputDecoration(
//                   labelText: 'Username',
//                   labelStyle: TextStyle(color: Colors.yellow[800]),
//                   focusedBorder: UnderlineInputBorder(
//                     borderSide:
//                         BorderSide(color: Color.fromARGB(0, 246, 156, 2)),
//                   ),
//                 ),
//                 validator: (value) {
//                   // if (value.isEmpty) {
//                   //   return 'Please enter a valid username';
//                   // }
//                   return null;
//                 },
//                 onSaved: (value) => _username = value,
//               ),
//               TextFormField(
//                 decoration: InputDecoration(
//                   labelText: 'Password',
//                   labelStyle: TextStyle(color: Colors.orange[800]),
//                   focusedBorder: UnderlineInputBorder(
//                     borderSide:
//                         BorderSide(color: Color.fromARGB(0, 246, 156, 2)),
//                   ),
//                   suffixIcon: IconButton(
//                     icon: Icon(
//                       _obscureText ? Icons.visibility : Icons.visibility_off,
//                       color: Colors.orange[800],
//                     ),
//                     onPressed: _toggleObscureText,
//                   ),
//                 ),
//                 obscureText: _obscureText,
//                 validator: (value) {
//                   // if (value.isEmpty) {
//                   //   return 'Please enter a password';
//                   // }
//                   return null;
//                 },
//                 onSaved: (value) => _password = value,
//               ),
//               RaisedButton(
//                 color: Colors.red[800],
//                 textColor: Colors.white,
//                 onPressed: () {
//                   // if (_formKey.currentState?.validate()) {
//                   //   _formKey.currentState.save();
//                   //   // TODO: Call the login API
//                   _userProvider.get();

//                   Navigator.pushNamed(context, CjenovnikPage.routeName);
//                   // }
//                 },
//                 child: Text('Login'),
//               ),
//             ],
//           ),
//         ),
//       ),
//     );
//   }
// }
