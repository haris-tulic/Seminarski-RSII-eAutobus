import 'package:eautobusmobile/models/redvoznje/RedVoznje.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class RedVoznjePage extends StatefulWidget {
  static const String routeName = "RasporedVoznje";
  const RedVoznjePage({Key? key}) : super(key: key);

  @override
  State<RedVoznjePage> createState() => _RedVoznjeState();
}

class _RedVoznjeState extends State<RedVoznjePage> {
  RedVoznjeProvider? _redVoznjeProvider = null;
  List<RedVoznje>? data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _redVoznjeProvider = context.read<RedVoznjeProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData = await _redVoznjeProvider?.get(null);
    setState(() {
      data = tempData;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        title: Text("Red voznje", style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.orange,
      ),
      body: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Container(
          child: DataTable(
            dataTextStyle: TextStyle(fontSize: 15, color: Colors.white),
            dataRowHeight: 70,
            columns: [
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
      ),
    );
  }
}
