import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/HomePage.dart';
import 'package:eautobusmobile/pages/RecenzijaPage.dart';
import 'package:eautobusmobile/pages/RedVoznjePage.dart';
import 'package:eautobusmobile/pages/korisnik/RegistracijaKorisnika.dart';
import 'package:eautobusmobile/providers/karta_provider.dart';
import 'package:eautobusmobile/providers/kartakupac_provider.dart';
import 'package:eautobusmobile/providers/login_provider.dart';
import 'package:eautobusmobile/providers/recenzija_provider.dart';
import 'package:eautobusmobile/providers/recommend_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:eautobusmobile/providers/registracija_provider.dart';
import 'package:eautobusmobile/providers/stanica_provider.dart';
import 'package:eautobusmobile/providers/tipkarte_provider.dart';
import 'package:eautobusmobile/providers/vrstakarte_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';
import '../../providers/cjenovnik_provider.dart';
import '../../providers/user_provider.dart';
import 'package:eautobusmobile/pages/InfoPage.dart';
import '.env';
import 'pages/RedVoznjeDetails.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey = stripePublishableKey;
  runApp(MultiProvider(
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
      ChangeNotifierProvider(create: (_) => RecommendProvider()),
    ],
    child: MaterialApp(
      debugShowCheckedModeBanner: true,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSwatch(primarySwatch: Colors.orange),
        scaffoldBackgroundColor: Colors.orange[200],
        appBarTheme: const AppBarTheme(
            backgroundColor: Colors.orange,
            titleTextStyle: TextStyle(color: Colors.white)),
      ),
      home: HomeApp(),
      onGenerateRoute: (settings) {
        if (settings.name == CjenovnikPage.routeName) {
          return MaterialPageRoute(
              builder: ((context) => const CjenovnikPage()));
        } else if (settings.name == RegistracijaPage.routeName) {
          return MaterialPageRoute(
              builder: ((context) => const RegistracijaPage()));
        } else if (settings.name == RedVoznjePage.routeName) {
          return MaterialPageRoute(
              builder: ((context) => const RedVoznjePage()));
        } else if (settings.name == HomePage.routeName) {
          return MaterialPageRoute(builder: ((context) => HomePage()));
        }
        var uri = Uri.parse(settings.name!);
        var putanja = uri.pathSegments.first.toString();
        if (uri.pathSegments.length == 2 && putanja == InfoPage.routeName) {
          var id = int.parse(uri.pathSegments[1]);
          return MaterialPageRoute(builder: ((context) => InfoPage(id)));
        } else if (uri.pathSegments.length == 2 &&
            putanja == RedVoznjePrikaz.routeName) {
          var id = int.parse(uri.pathSegments[1]);
          return MaterialPageRoute(
              builder: ((context) => RedVoznjePrikaz(
                    id,
                  )));
        } else if (uri.pathSegments.length == 2 &&
            putanja == RecenzijaPage.routeName) {
          var id = int.parse(uri.pathSegments[1]);
          return MaterialPageRoute(builder: ((context) => RecenzijaPage(id)));
        }

        return null;
      },
    ),
  ));
}

class HomeApp extends StatefulWidget {
  @override
  State<HomeApp> createState() => _HomeAppState();
}

class _HomeAppState extends State<HomeApp> {
  @override
  Widget build(BuildContext context) {
    return HomePage();
  }
}
