import 'package:eautobusmobile/main.dart';
import 'package:eautobusmobile/models/korisnik/Korisnik.dart';
import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/RecenzijaPage.dart';
import 'package:eautobusmobile/pages/RedVoznjePage.dart';
import 'package:eautobusmobile/pages/RezervacijaKarte.dart';
import 'package:eautobusmobile/providers/user_provider.dart';
import 'package:eautobusmobile/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class InfoPage extends StatefulWidget {
  static const String routeName = "Pocetna";
  String? username;
  dynamic korisnikId;
  InfoPage({Key? key, required this.korisnikId});

  @override
  State<InfoPage> createState() => _InfoPageState();
}

class _InfoPageState extends State<InfoPage> {
  KorisnikProvider? _korisnikProvider = null;
  Korisnik? korisnik;
  int? id;
  @override
  void initState() {
    super.initState();
    _korisnikProvider = context.read<KorisnikProvider>();
    loadData();
  }

  Future loadData() async {
    var data = await _korisnikProvider?.getById(widget.korisnikId);
    setState(() {
      korisnik = data!;
    });
    void logout() async {
      Authorization.username = "";
      Authorization.password = "";

      Navigator.of(context)
          .pop(MaterialPageRoute(builder: ((context) => HomePage())));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
          backgroundColor: Colors.orange,
          title: const Text(
            "Pocetna",
            style: TextStyle(color: Colors.white),
          )),
      drawer: Drawer(
        backgroundColor: Color.fromARGB(255, 255, 125, 39),
        child: ListView(
          children: <Widget>[
            UserAccountsDrawerHeader(
              decoration:
                  BoxDecoration(color: Color.fromARGB(255, 255, 108, 10)),
              arrowColor: Colors.white,
              accountName: Text('${korisnik?.korisnickoIme}',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              accountEmail: Text('${korisnik?.email}',
                  style: const TextStyle(color: Colors.white, fontSize: 18)),
              currentAccountPicture: CircleAvatar(
                backgroundColor: Colors.white,
                child: Text(
                  '${korisnik?.ime!.substring(0, 1)}${korisnik?.prezime!.substring(0, 1)}',
                  style: TextStyle(fontSize: 40.0),
                ),
              ),
            ),
            ListTile(
              leading: Icon(Icons.home),
              iconColor: Colors.white,
              title: Text('Pocetna',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              onTap: () {},
            ),
            ListTile(
              leading: Icon(Icons.price_change_rounded),
              iconColor: Colors.white,
              title: Text('Cjenovnik',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              onTap: () {
                Navigator.of(context).push(
                    MaterialPageRoute(builder: (context) => CjenovnikPage()));
              },
            ),
            ListTile(
              leading: Icon(Icons.calendar_month_outlined),
              title: Text('Red voznje',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context).push(
                    MaterialPageRoute(builder: (context) => RedVoznjePage()));
              },
            ),
            ListTile(
              leading: Icon(Icons.receipt_long_outlined),
              title: Text('Rezervacija karte',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => RezervacijaKarte(),
                ));
              },
            ),
            ListTile(
              leading: Icon(Icons.recommend),
              title: Text('Recenzija',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => RecenzijaPage(),
                ));
              },
            ),
            Divider(),
            ListTile(
              leading: Icon(Icons.exit_to_app),
              title: Text('Logout',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context)
                    .pop(MaterialPageRoute(builder: ((context) => HomePage())));
              },
            ),
          ],
        ),
      ),
      body: Center(
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              "Dobrodosli nazad \n ${korisnik?.ime} ${korisnik?.prezime}",
              textAlign: TextAlign.center,
              style: TextStyle(color: Colors.white, fontSize: 24),
            ),
          ],
        ),
      ),
    );
  }
}
