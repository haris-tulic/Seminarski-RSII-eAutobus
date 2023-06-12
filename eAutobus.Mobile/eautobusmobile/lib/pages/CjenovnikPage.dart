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
      appBar: AppBar(
          title: const Text(
        "Cjenovnik",
      )),
      body: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        padding: const EdgeInsets.fromLTRB(20, 60, 0, 50),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisSize: MainAxisSize.max,
            verticalDirection: VerticalDirection.down,
            children: [
              const Center(
                child: Text(
                  "Pregled cjenovnika:",
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
              const SizedBox(
                height: 40,
              ),
              Flexible(
                child: Container(
                  width: 350,
                  decoration: BoxDecoration(
                    color: Colors.orange[400],
                    border: Border.all(color: Colors.white),
                  ),
                  child: DropdownButtonFormField(
                      isDense: true,
                      dropdownColor: Colors.orange[300],
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
                                  Text(
                                    "${kartaT.naziv}",
                                  )
                                ],
                              ))
                      ],
                      onChanged: (value) {
                        tipKarte = value as int;
                      }),
                ),
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
                decoration: BoxDecoration(
                  color: Colors.yellow[900],
                  border: Border.all(color: Colors.white),
                  borderRadius: BorderRadius.all(Radius.circular(20)),
                  boxShadow: [
                    BoxShadow(
                      color:
                          Color.fromARGB(255, 255, 255, 255).withOpacity(0.9),
                      spreadRadius: 2,
                      blurRadius: 5,
                      offset: Offset(0, 1),
                    ),
                  ],
                ),
                child: DataTable(
                  dataTextStyle: TextStyle(fontSize: 15, color: Colors.white),
                  columns: [
                    DataColumn(
                        label: Text(
                      'Vrsta karte',
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    )),
                    DataColumn(
                        label: Text('Tip karte',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    DataColumn(
                        label: Text('Polaziste',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    DataColumn(
                        label: Text('Odrediste',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
                    DataColumn(
                        label: Text('Cijena karte',
                            style:
                                TextStyle(color: Colors.white, fontSize: 18))),
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
              ),
            ],
          ),
        ),
      ),
    );
  }
}
