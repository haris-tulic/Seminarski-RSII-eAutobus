import 'package:eautobusmobile/models/cjenovnik/Cjenovnik.dart';
import 'package:eautobusmobile/providers/cjenovnik_provider.dart';
import 'package:eautobusmobile/providers/tipkarte_provider.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/karta/TipKarte.dart';

class CjenovnikPage extends StatefulWidget {
  static const String routeName = "Cjenovnik";
  const CjenovnikPage({Key? key}) : super(key: key);

  @override
  State<CjenovnikPage> createState() => _CjenovnikState();
}

class _CjenovnikState extends State<CjenovnikPage> {
  CjenovnikProvider? _cjenovnikProvider = null;
  TipKarteProvider? _tipKarteProvider = null;
  List<Cjenovnik>? data = [];
  List<TipKarte>? karte = [];
  int? tipKarte = null;
  Cjenovnik? sve = null;

  @override
  void initState() {
    super.initState();
    _cjenovnikProvider = context.read<CjenovnikProvider>();
    _tipKarteProvider = context.read<TipKarteProvider>();
    loadData();
    loadTipKarte();
  }

  Future loadData() async {
    Map request = {"tipkarteID": tipKarte};
    var tmpData = await _cjenovnikProvider?.get(request);
    setState(
      () {
        data = tmpData!;
        tipKarte = null;
      },
    );
  }

  Future loadTipKarte() async {
    var tempKarte = await _tipKarteProvider?.get();
    setState(() {
      karte = tempKarte!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: _cjenovnikHeader(),
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        padding: EdgeInsets.fromLTRB(0, 50, 0, 0),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Container(
                width: 300,
                child: DropdownButtonFormField(
                    isDense: true,
                    dropdownColor: Colors.grey,
                    style: const TextStyle(color: Colors.white),
                    decoration: const InputDecoration(
                      labelText: 'Odaberite tip karte',
                      labelStyle: TextStyle(color: Colors.white),
                      border: OutlineInputBorder(),
                    ),
                    value: tipKarte != null ? tipKarte : null,
                    items: [
                      for (final kartaT in karte!)
                        DropdownMenuItem(
                            value: kartaT.tipKarteID,
                            child: Row(
                              children: [
                                kartaT == null
                                    ? Text("Pretrazi sve")
                                    : Text(
                                        "${kartaT.naziv}",
                                      )
                              ],
                            ))
                    ],
                    onChanged: (value) {
                      tipKarte = value as int;
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
              DataTable(
                dataTextStyle: TextStyle(fontSize: 15, color: Colors.white),
                columns: [
                  DataColumn(
                      label: Text(
                    'Vrsta karte',
                    style: TextStyle(color: Colors.white, fontSize: 18),
                  )),
                  DataColumn(
                      label: Text('Tip karte',
                          style: TextStyle(color: Colors.white, fontSize: 18))),
                  DataColumn(
                      label: Text('Polaziste',
                          style: TextStyle(color: Colors.white, fontSize: 18))),
                  DataColumn(
                      label: Text('Odrediste',
                          style: TextStyle(color: Colors.white, fontSize: 18))),
                  DataColumn(
                      label: Text('Cijena karte',
                          style: TextStyle(color: Colors.white, fontSize: 18))),
                ],
                rows: data!
                    .map(
                      (data) => DataRow(
                        cells: [
                          DataCell(Text(data.vrstaKarte!)),
                          DataCell(Text(data.tipKarte!)),
                          DataCell(Text(data.polaziste!)),
                          DataCell(Text(data.odrediste!)),
                          DataCell(Text(data.cijenaPrikaz!)),
                        ],
                      ),
                    )
                    .toList(),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _cjenovnikHeader() {
    return Container(
      padding: EdgeInsets.all(20),
      child: Text(
        "Cjenovnik",
        style: TextStyle(
          color: Colors.white,
          fontSize: 40,
          fontWeight: FontWeight.w500,
          backgroundColor: Colors.orange,
        ),
      ),
    );
  }
}
