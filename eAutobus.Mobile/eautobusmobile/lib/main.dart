import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/HomePage.dart';
import 'package:eautobusmobile/pages/RecenzijaPage.dart';
import 'package:eautobusmobile/pages/RedVoznjePage.dart';
import 'package:eautobusmobile/pages/korisnik/RegistracijaKorisnika.dart';
import 'package:eautobusmobile/providers/karta_provider.dart';
import 'package:eautobusmobile/providers/kartakupac_provider.dart';
import 'package:eautobusmobile/providers/login_provider.dart';
import 'package:eautobusmobile/providers/recenzija_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:eautobusmobile/providers/registracija_provider.dart';
import 'package:eautobusmobile/providers/stanica_provider.dart';
import 'package:eautobusmobile/providers/tipkarte_provider.dart';
import 'package:eautobusmobile/providers/vrstakarte_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../../providers/cjenovnik_provider.dart';
import '../../providers/user_provider.dart';
import 'package:eautobusmobile/pages/InfoPage.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => CjenovnikProvider()),
        ChangeNotifierProvider(create: (_) => KorisnikProvider()),
        ChangeNotifierProvider(create: (_) => RegistracijaProvider()),
        ChangeNotifierProvider(create: (_) => RedVoznjeProvider()),
        ChangeNotifierProvider(create: (_) => KartaProvider()),
        ChangeNotifierProvider(create: (_) => LoginProvider()),
        ChangeNotifierProvider(create: (_) => RecenzijaProvider()),
        ChangeNotifierProvider(create: (_) => StanicaProvider()),
        ChangeNotifierProvider(create: (_) => VrstaKarteProvider()),
        ChangeNotifierProvider(create: (_) => TipKarteProvider()),
        ChangeNotifierProvider(create: (_) => KartaKupacProvider()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          brightness: Brightness.light,
          primaryColor: const Color.fromARGB(255, 183, 160, 58),
          textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                  textStyle: const TextStyle(
                      fontSize: 24,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic))),
          textTheme: const TextTheme(),
        ),
        home: HomeApp(),
        onGenerateRoute: (settings) {
          if (settings.name == CjenovnikPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const CjenovnikPage()));
          } else if (settings.name == RegistracijaPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const RegistracijaPage()));
          } else if (settings.name == RecenzijaPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const RecenzijaPage(
                      kupacID: null,
                    )));
          } else if (settings.name == RedVoznjePage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => const RedVoznjePage()));
          } else if (settings.name == InfoPage.routeName) {
            return MaterialPageRoute(
                builder: ((context) => InfoPage(
                      korisnikId: null,
                    )));
          } else if (settings.name == HomePage.routeName) {
            return MaterialPageRoute(builder: ((context) => HomePage()));
          }
          return null;
        },
      ),
    ));

class HomeApp extends StatefulWidget {
  static const String? routeName = "Home";
  @override
  State<HomeApp> createState() => _HomeAppState();
}

class _HomeAppState extends State<HomeApp> {
  @override
  Widget build(BuildContext context) {
    return HomePage();
  }
}
