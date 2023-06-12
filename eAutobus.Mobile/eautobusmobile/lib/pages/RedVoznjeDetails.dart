import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../models/redvoznje/RedVoznje.dart';

class RedVoznjePrikaz extends StatefulWidget {
  static const String routeName = "RasporedVoznjePrikaz";
  final int? redVoznjeID;
  const RedVoznjePrikaz({
    super.key,
    this.redVoznjeID,
  });

  @override
  State<RedVoznjePrikaz> createState() => _RedVoznjePrikazState();
}

class _RedVoznjePrikazState extends State<RedVoznjePrikaz> {
  RedVoznje? data = null;
  RedVoznjeProvider? _redVoznjeProvider = null;
  @override
  void initState() {
    super.initState();
    _redVoznjeProvider = context.read<RedVoznjeProvider>();
    loadData();
  }

  Future loadData() async {
    var temp = await _redVoznjeProvider?.getById(widget.redVoznjeID!);
    setState(() {
      data = temp;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: const Text("Prikaz detalja")),
        body: SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          padding: EdgeInsets.fromLTRB(20, 50, 0, 50),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                textDirection: TextDirection.ltr,
                children: [
                  Text(data!.brojLinije!.toString()),
                  Text(data!.nazivLinije!),
                  Text(data!.brojAutobusa!.toString()),
                  Text(data!.vozacIme!),
                  Text(data!.polazak!),
                  Text(data!.vrijemePolaska!.substring(11)),
                  Text(data!.odlazak!),
                  Text(data!.vrijemeDolaska!.substring(11)),
                  Text(data!.datum!.substring(0, 10)),
                  Text(data!.finalOcjena!.toString()),
                ],
              )
            ],
          ),
        ));
  }
}
