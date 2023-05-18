import 'package:eautobusmobile/models/redvoznje/RedVoznje.dart';
import 'package:eautobusmobile/providers/recenzija_provider.dart';
import 'package:eautobusmobile/providers/redvoznje_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

final List<String?> vrstaUsluge = ["Osoblje", "Vozilo"];

class RecenzijaPage extends StatefulWidget {
  static const String routeName = "Recenzija";
  final int? kupacID;
  const RecenzijaPage({Key? key, this.kupacID}) : super(key: key);

  @override
  State<RecenzijaPage> createState() => _RecenzijaState();
}

class _RecenzijaState extends State<RecenzijaPage> {
  TextEditingController _komentar = TextEditingController();
  RedVoznjeProvider? _redVoznje = null;
  RecenzijaProvider? _recenzijaProvider = null;

  Map? recenzija;
  List<RedVoznje>? data = [];
  int? _odabranaLinijaID = null;
  late double _ocjena = 1;
  DateTime? _datum = DateTime.now();
  String? usluga = null;

  @override
  void initState() {
    super.initState();
    _redVoznje = context.read<RedVoznjeProvider>();
    _recenzijaProvider = context.read<RecenzijaProvider>();
    loadData();
  }

  Future loadData() async {
    var temp = await _redVoznje?.get(null);
    setState(() {
      data = temp;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromARGB(255, 248, 183, 86),
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: Text(
          "Ostavite recenziju",
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: SingleChildScrollView(
        child: Center(
          child: Form(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              mainAxisSize: MainAxisSize.min,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Text(
                      "Linija: ",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                    const SizedBox(width: 30),
                    Container(
                      width: 500,
                      child: DropdownButtonFormField(
                        isDense: true,
                        decoration: const InputDecoration(
                          labelText: 'Odaberite liniju',
                          labelStyle: TextStyle(color: Colors.white),
                          border: OutlineInputBorder(),
                        ),
                        style: const TextStyle(color: Colors.white),
                        value: _odabranaLinijaID,
                        dropdownColor: Colors.grey,
                        items: [
                          for (final linija in data!)
                            DropdownMenuItem(
                              value: linija.rasporedVoznjeID,
                              child: Row(
                                children: [
                                  Text(
                                    "${linija.brojLinije} ${linija.nazivLinije}",
                                    style: const TextStyle(
                                      color: Colors.white,
                                    ),
                                  )
                                ],
                              ),
                            ),
                        ],
                        onChanged: (value) {
                          setState(() {
                            _odabranaLinijaID = value as int;
                          });
                        },
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 30),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Text(
                      "Usluga: ",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                    const SizedBox(width: 15),
                    Container(
                      width: 500,
                      child: DropdownButtonFormField(
                        isDense: true,
                        decoration: const InputDecoration(
                          labelText: 'Odaberite vrstu usluge',
                          labelStyle: TextStyle(color: Colors.white),
                          border: OutlineInputBorder(),
                        ),
                        style: const TextStyle(color: Colors.white),
                        value: usluga,
                        dropdownColor: Colors.grey,
                        items: [
                          for (final u in vrstaUsluge!)
                            DropdownMenuItem(
                              value: u,
                              child: Row(
                                children: [
                                  Text(
                                    "${u}",
                                    style: const TextStyle(
                                      color: Colors.white,
                                    ),
                                  )
                                ],
                              ),
                            ),
                        ],
                        onChanged: (value) {
                          setState(() {
                            usluga = value as String;
                          });
                        },
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 40),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Text(
                      "Komentar: ",
                      style: TextStyle(color: Colors.white, fontSize: 18),
                    ),
                    Container(
                      width: 500,
                      child: TextFormField(
                        controller: _komentar,
                        decoration: InputDecoration(
                          labelText: "Ostavite komentar",
                          labelStyle: TextStyle(color: Colors.white),
                          border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(5)),
                        ),
                        style: const TextStyle(color: Colors.white),
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 40),
                const Text(
                  "Ocjena:",
                  style: TextStyle(color: Colors.white, fontSize: 18),
                ),
                const SizedBox(width: 20),
                Container(
                  width: 500,
                  child: Slider(
                      value: _ocjena,
                      min: 1,
                      max: 5,
                      onChanged: (value) {
                        setState(() {
                          _ocjena = value;
                        });
                      },
                      activeColor: Colors.white,
                      inactiveColor: Colors.white60,
                      divisions: 4,
                      label: '${_ocjena.round()}'),
                ),
                const SizedBox(height: 30),
                Material(
                  elevation: 5.0,
                  borderRadius: BorderRadius.circular(30.0),
                  child: MaterialButton(
                    color: Color.fromARGB(255, 255, 81, 0),
                    padding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                    onPressed: () async {
                      setState(() {
                        recenzija = {
                          "komentar": _komentar.text,
                          "datumRecenzije": _datum?.toIso8601String(),
                          "ocjena": _ocjena.toInt(),
                          "rasporedVoznjeID": _odabranaLinijaID,
                          "vrstaUsluga": usluga,
                          "kupacID": widget.kupacID,
                        };
                      });
                      try {
                        await _recenzijaProvider?.insert(recenzija);
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text(
                                    "Hvala vam na recenziji!",
                                    style: TextStyle(color: Colors.white),
                                  ),
                                  backgroundColor: Colors.grey,
                                  actions: [
                                    TextButton(
                                      child: Text(
                                        "Ok",
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onPressed: () => Navigator.pop(context),
                                    )
                                  ],
                                ));
                      } catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text(
                                      "Recenzija nije uspjela. Pokusajte ponovo kasnije."),
                                  content: Text(e.toString()),
                                  actions: [
                                    TextButton(
                                      child: Text("Ok"),
                                      onPressed: () => Navigator.pop(context),
                                    )
                                  ],
                                ));
                      }
                    },
                    child: Text("Ocijeni",
                        textAlign: TextAlign.center,
                        style: TextStyle(
                            color: Colors.white, fontWeight: FontWeight.bold)),
                  ),
                )
              ],
            ),
          ),
        ),
      ),
    );
  }
}