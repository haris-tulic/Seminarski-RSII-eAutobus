import 'package:eautobusmobile/models/korisnik/Korisnik.dart';
import 'package:eautobusmobile/pages/CjenovnikPage.dart';
import 'package:eautobusmobile/pages/HomePage.dart';
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
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
          backgroundColor: Colors.orange,
          title: const Text(
            "Pocetna",
            style: TextStyle(color: Colors.white),
          )),
      drawer: Drawer(
        backgroundColor: const Color.fromARGB(255, 255, 125, 39),
        child: ListView(
          children: <Widget>[
            UserAccountsDrawerHeader(
              decoration:
                  const BoxDecoration(color: Color.fromARGB(255, 255, 108, 10)),
              arrowColor: Colors.white,
              accountName: Text('${korisnik?.korisnickoIme}',
                  style: const TextStyle(color: Colors.white, fontSize: 18)),
              accountEmail: Text('${korisnik?.email ?? " "}',
                  style: const TextStyle(color: Colors.white, fontSize: 18)),
              currentAccountPicture: CircleAvatar(
                backgroundColor: Colors.yellow,
                child: Text(
                  '${korisnik?.ime!.substring(0, 1)}${korisnik?.prezime!.substring(0, 1)}',
                  style: const TextStyle(fontSize: 40.0, color: Colors.red),
                ),
              ),
            ),
            ListTile(
              leading: const Icon(Icons.price_change_rounded),
              iconColor: Colors.white,
              title: const Text('Cjenovnik',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => const CjenovnikPage()));
              },
            ),
            ListTile(
              leading: const Icon(Icons.calendar_month_outlined),
              title: const Text('Red voznje',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => const RedVoznjePage()));
              },
            ),
            ListTile(
              leading: const Icon(Icons.receipt_long_outlined),
              title: const Text('Rezervacija karte',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () async {
                final result =
                    await Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => RezervacijaKarte(
                    korisnik: korisnik,
                  ),
                ));
                if (result == true) {
                  loadData();
                }
              },
            ),
            ListTile(
              leading: const Icon(Icons.recommend),
              title: const Text('Recenzija',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) =>
                      RecenzijaPage(kupacID: korisnik?.kupacID),
                ));
              },
            ),
            const Divider(height: 15),
            ListTile(
              leading: const Icon(Icons.exit_to_app),
              title: const Text('Logout',
                  style: TextStyle(color: Colors.white, fontSize: 18)),
              iconColor: Colors.white,
              onTap: () async {
                Authorization.username = " ";
                Authorization.password = " ";
                Navigator.of(context).pushAndRemoveUntil(
                  MaterialPageRoute(builder: (context) => HomePage()),
                  (Route<dynamic> route) => false,
                );
              },
            ),
          ],
        ),
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Center(
          child: Container(
            padding: EdgeInsets.fromLTRB(0, 100, 0, 0),
            alignment: Alignment.center,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Text(
                  "Dobrodosli nazad \n ${korisnik?.ime} ${korisnik?.prezime}",
                  textAlign: TextAlign.center,
                  style: const TextStyle(
                      color: Colors.white,
                      fontSize: 24,
                      fontWeight: FontWeight.bold),
                ),
                const SizedBox(height: 50),
                const Text(
                  "Historija karata: ",
                  style: TextStyle(color: Colors.white, fontSize: 22),
                ),
                const SizedBox(height: 30),
                DataTable(
                  dataTextStyle:
                      const TextStyle(fontSize: 15, color: Colors.white),
                  border: TableBorder.all(
                      color: Color.fromARGB(207, 255, 255, 255),
                      width: 2,
                      style: BorderStyle.solid),
                  columns: [
                    const DataColumn(
                      label: Text(
                        "Karta",
                        style: TextStyle(
                            color: Colors.white,
                            fontSize: 16,
                            fontWeight: FontWeight.bold),
                      ),
                    ),
                    const DataColumn(
                        label: Text("Polaziste",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 18,
                                fontWeight: FontWeight.bold))),
                    const DataColumn(
                        label: Text("Odrediste",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 18,
                                fontWeight: FontWeight.bold))),
                    const DataColumn(
                        label: Text("Datum vadjenja karte",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 18,
                                fontWeight: FontWeight.bold))),
                    const DataColumn(
                        label: Text("Datum vazenja karte",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 18,
                                fontWeight: FontWeight.bold))),
                    const DataColumn(
                        label: Text("Aktivna",
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 18,
                                fontWeight: FontWeight.bold))),
                  ],
                  rows: korisnik != null
                      ? korisnik!.karte!
                          .map(
                            (_historijaKarata) => DataRow(
                              cells: [
                                DataCell(Text(_historijaKarata.karta!)),
                                DataCell(Text(_historijaKarata.polaziste!)),
                                DataCell(Text(_historijaKarata.odrediste!)),
                                DataCell(Text(_historijaKarata
                                    .datumVadjenjaKarte
                                    .toString()
                                    .substring(0, 19))),
                                DataCell(Text(_historijaKarata.datumVazenjaKarte
                                    .toString()
                                    .substring(0, 19))),
                                DataCell(Checkbox(
                                  value: _historijaKarata.aktivna,
                                  onChanged: null,
                                )),
                              ],
                            ),
                          )
                          .toList()
                      : [],
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
