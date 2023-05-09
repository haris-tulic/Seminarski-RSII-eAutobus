import 'package:flutter/material.dart';

class RecenzijaPage extends StatefulWidget {
  static const String routeName = "Recenzija";
  const RecenzijaPage({Key? key}) : super(key: key);

  @override
  State<RecenzijaPage> createState() => _RecenzijaState();
}

class _RecenzijaState extends State<RecenzijaPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.orange,
        title: Text(
          "Ostavite recenziju",
          style: TextStyle(color: Colors.white),
        ),
      ),
      body: Text(""),
    );
  }
}
