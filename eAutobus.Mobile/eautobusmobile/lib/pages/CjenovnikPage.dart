import 'package:eautobusmobile/models/cjenovnik/Cjenovnik.dart';
import 'package:eautobusmobile/providers/cjenovnik_provider.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class CjenovnikPage extends StatefulWidget {
  static const String routeName = "Cjenovnik";
  const CjenovnikPage({Key? key}) : super(key: key);

  @override
  State<CjenovnikPage> createState() => _CjenovnikState();
}

class _CjenovnikState extends State<CjenovnikPage> {
  CjenovnikProvider? _cjenovnikProvider = null;
  List<Cjenovnik> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _cjenovnikProvider = context.read<CjenovnikProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _cjenovnikProvider?.get(null);
    setState(
      () {
        data = tmpData!;
      },
    );
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
        scrollDirection: Axis.horizontal,
        child: Container(
          child: DataTable(
            dataTextStyle: TextStyle(fontSize: 15, color: Colors.white),
            dataRowHeight: 70,
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
            rows: data
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
