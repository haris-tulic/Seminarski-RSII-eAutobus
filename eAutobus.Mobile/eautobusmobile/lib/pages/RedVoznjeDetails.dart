import 'package:eautobusmobile/providers/recommend_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../models/redvoznje/RedVoznje.dart';

class RedVoznjePrikaz extends StatefulWidget {
  static const String routeName = "RasporedVoznjeDetails";
  final int? redVoznjeID;
  const RedVoznjePrikaz(
    this.redVoznjeID, {
    super.key,
  });

  @override
  State<RedVoznjePrikaz> createState() => _RedVoznjePrikazState();
}

class _RedVoznjePrikazState extends State<RedVoznjePrikaz> {
  RedVoznje data = RedVoznje();
  RedVoznjeProvider? _redVoznjeProvider = null;
  RecommendProvider? _recommendProvider = null;
  List<RedVoznje>? listaPreporuka = [];
  @override
  void initState() {
    super.initState();
    _redVoznjeProvider = context.read<RedVoznjeProvider>();
    _recommendProvider = context.read<RecommendProvider>();
    loadData();
    loadRecommend();
  }

  Future loadData() async {
    var temp = await _redVoznjeProvider?.getById(widget.redVoznjeID!);
    setState(() {
      data = temp!;
    });
  }

  Future loadRecommend() async {
    var temp = await _recommendProvider?.getPreporuke(widget.redVoznjeID!);
    setState(() {
      listaPreporuka = temp;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: const Text("Prikaz detalja")),
        body: prikazKarte());
  }

  Widget prikazKarte() {
    if (data == null) {
      return const Text("Loading...");
    }
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      padding: const EdgeInsets.fromLTRB(20, 30, 0, 5),
      child: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              textDirection: TextDirection.ltr,
              children: [
                prikazOdabranog(),
                const SizedBox(
                  height: 150,
                ),
                const Text(
                  "Prijedlozi:",
                  style: TextStyle(color: Colors.black, fontSize: 18),
                ),
                const SizedBox(height: 20),
                prikazPredlozenih(),
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget prikazPredlozenih() {
    return Container(
      decoration: BoxDecoration(
        color: Colors.yellow[900],
        border: Border.all(color: Colors.white),
        borderRadius: BorderRadius.all(Radius.circular(20)),
        boxShadow: [
          BoxShadow(
            color: Color.fromARGB(255, 255, 255, 255).withOpacity(0.9),
            spreadRadius: 2,
            blurRadius: 5,
            offset: Offset(0, 1),
          ),
        ],
      ),
      child: DataTable(
        dataTextStyle: const TextStyle(fontSize: 15, color: Colors.white),
        columns: const [
          DataColumn(
              label: Text(
            'Broj linije',
            style: TextStyle(color: Colors.white, fontSize: 18),
          )),
          DataColumn(
              label: Text('Polazak',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Vrijeme polaska',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Odrediste',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Vrijeme dolaska',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Datum',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Broj autobusa',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
          DataColumn(
              label: Text('Ocjena',
                  style: TextStyle(color: Colors.white, fontSize: 18))),
        ],
        rows: listaPreporuka!
            .map(
              (data) => DataRow(
                cells: [
                  DataCell(Text(data.brojLinije.toString())),
                  DataCell(Text(data.polazak.toString())),
                  DataCell(Text(data.vrijemePolaska!.substring(11))),
                  DataCell(Text(data.odlazak.toString())),
                  DataCell(Text(data.vrijemeDolaska!.substring(11))),
                  DataCell(Text(data.datum!.substring(0, 10))),
                  DataCell(Text(data.brojAutobusa.toString())),
                  DataCell(Text(data.finalOcjena.toString())),
                ],
              ),
            )
            .toList(),
      ),
    );
  }

  Widget prikazOdabranog() {
    return Container(
      decoration: BoxDecoration(
        color: Colors.yellow[900],
        border: Border.all(color: Colors.white),
        borderRadius: BorderRadius.all(Radius.circular(20)),
        boxShadow: [
          BoxShadow(
            color: Color.fromARGB(255, 255, 255, 255).withOpacity(0.9),
            spreadRadius: 2,
            blurRadius: 5,
            offset: Offset(0, 1),
          ),
        ],
      ),
      child: DataTable(
          dataTextStyle: const TextStyle(fontSize: 15, color: Colors.white),
          columns: const [
            DataColumn(
                label: Text(
              'Broj linije',
              style: TextStyle(color: Colors.white, fontSize: 18),
            )),
            DataColumn(
                label: Text('Naziv linije',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Polazak',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Vrijeme polaska',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Odrediste',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Vrijeme dolaska',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Datum',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Broj autobusa',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Vozac',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
            DataColumn(
                label: Text('Ocjena',
                    style: TextStyle(color: Colors.white, fontSize: 18))),
          ],
          rows: [
            DataRow(cells: [
              DataCell(Text(data.brojLinije.toString())),
              DataCell(Text(data.nazivLinije.toString())),
              DataCell(Text(data.polazak.toString())),
              DataCell(Text(data.vrijemePolaska.toString())),
              DataCell(Text(data.odlazak.toString())),
              DataCell(Text(data.vrijemeDolaska.toString())),
              DataCell(Text(data.datum.toString())),
              DataCell(Text(data.brojAutobusa.toString())),
              DataCell(Text(data.vozacIme.toString())),
              DataCell(Text(data.finalOcjena.toString())),
            ])
          ]),
    );
  }
}
