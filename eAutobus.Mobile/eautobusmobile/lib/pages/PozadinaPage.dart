import 'package:flutter/material.dart';

class PozadinaPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        image: DecorationImage(
          image: AssetImage('assets/images/bus_picture.jpg'),
          fit: BoxFit.cover,
        ),
      ),
    );
  }
}
