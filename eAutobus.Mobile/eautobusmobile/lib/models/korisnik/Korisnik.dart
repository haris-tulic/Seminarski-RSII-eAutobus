import 'package:flutter/material.dart';

class Korisnik {
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;
  String? brojTelefona;

  Korisnik({
    this.korisnickoIme,
    this.ime,
    this.prezime,
    this.email,
    this.brojTelefona,
  });

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
        korisnickoIme: json['korisnickoIme'] as String,
        ime: json['ime'] as String,
        prezime: json['prezime'] as String,
        email: json['email'] as String,
        brojTelefona: json['brojTelefona'] as String);
  }

  Map<String, dynamic> toJson() => {
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "brojTelefona": brojTelefona
      };
}
