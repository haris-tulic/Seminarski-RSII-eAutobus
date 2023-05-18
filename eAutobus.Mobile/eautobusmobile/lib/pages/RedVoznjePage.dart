import 'package:eautobusmobile/models/redvoznje/RedVoznje.dart';
import 'package:eautobusmobile/models/redvoznje/Stanica.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/stanica_provider.dart';

class RedVoznjePage extends StatefulWidget {
  static const String routeName = "RasporedVoznje";
  const RedVoznjePage({Key? key}) : super(key: key);

  @override
  State<RedVoznjePage> createState() => _RedVoznjeState();
}

class _RedVoznjeState extends State<RedVoznjePage> {
  RedVoznjeProvider? _redVoznjeProvider = null;
  StanicaProvider? _stanicaProvider = null;
  List<RedVoznje>? data = [];
  List<Stanica>? stanice = [];
  int? polazisteID = null;

  @override
  void initState() {
    super.initState();
    _redVoznjeProvider = context.read<RedVoznjeProvider>();
    _stanicaProvider = context.read<StanicaProvider>();
    loadData();
    loadStanice();
  }

  Future loadData() async {
    Map request = {"polazisteID": polazisteID};
    var tempData = await _redVoznjeProvider?.get(request);
    setState(() {
      data = tempData;
      polazisteID = null;
    });
  }

  Future loadStanice() async {
    var tempStanice = await _stanicaProvider?.get();
    setState(() {
      stanice = tempStanice;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        title: const Text("Red voznje", style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.orange,
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Center(
          child: Column(
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
                    value: polazisteID != null ? polazisteID : null,
                    items: [
                      for (final polaziste in stanice!)
                        DropdownMenuItem(
                          value: polaziste.stanicaID,
                          child: Row(
                            children: [
                              Text("${polaziste.nazivLokacijestanice}"),
                            ],
                          ),
                        ),
                    ],
                    onChanged: (value) {
                      setState(() {
                        polazisteID = value as int;
                      });
                    }),
              ),
              const SizedBox(height: 30),
              Material(
                elevation: 5.0,
                borderRadius: BorderRadius.circular(30.0),
                child: MaterialButton(
                  child: Text(
                    "Pretraga",
                    textAlign: TextAlign.center,
                    style: TextStyle(color: Colors.white),
                  ),
                  color: Color.fromARGB(255, 255, 81, 0),
                  padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                  onPressed: () {
                    setState(() {
                      loadData();
                    });
                  },
                ),
              ),
              const SizedBox(height: 30),
              Container(
                child: DataTable(
                  dataTextStyle:
                      const TextStyle(fontSize: 15, color: Colors.white),
                  columns: [
                    const DataColumn(
                        label: Text(
                      'Broj linije',
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    )),
                    const DataColumn(
                        label: const Text('Polazak',
                            style: const TextStyle(
                                color: Colors.white, fontSize: 18))),
                    const DataColumn(
                        label: Text('Vrijeme polaska',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    const DataColumn(
                        label: const Text('Odrediste',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    const DataColumn(
                        label: const Text('Vrijeme dolaska',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    const DataColumn(
                        label: Text('Datum',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    const DataColumn(
                        label: Text('Broj autobusa',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                  ],
                  rows: data!
                      .map(
                        (data) => DataRow(
                          cells: [
                            DataCell(Text(data.brojLinije.toString())),
                            DataCell(Text(data.polazak!)),
                            DataCell(Text(data.vrijemePolaska!.substring(11))),
                            DataCell(Text(data.odlazak!)),
                            DataCell(Text(data.vrijemeDolaska!.substring(11))),
                            DataCell(Text(data.datum!.substring(0, 10))),
                            DataCell(Text(data.brojAutobusa.toString())),
                          ],
                        ),
                      )
                      .toList(),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
