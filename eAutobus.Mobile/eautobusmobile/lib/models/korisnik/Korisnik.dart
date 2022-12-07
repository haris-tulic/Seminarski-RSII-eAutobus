import 'package:flutter/material.dart';

class Korisnik {
  int? id;
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;
  DateTime? datumRodjenja;
  String? lozinkaHash;
  String? lozinkaSalt;
  String? lozinka;

  Korisnik({
    this.id,
    this.korisnickoIme,
    this.ime,
    this.prezime,
    this.email,
    this.datumRodjenja,
    this.lozinkaHash,
    this.lozinkaSalt,
    this.lozinka,
  });

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
        id: json['id'] as int,
        korisnickoIme: json['korisnickoIme'] as String,
        ime: json['ime'] as String,
        prezime: json['prezime'] as String,
        email: json['email'] as String,
        datumRodjenja: DateTime.tryParse(json['datumRodjenja']),
        lozinkaHash: json['lozinkaHash'] as String,
        lozinkaSalt: json['lozinkaSalt'] as String,
        lozinka: json['lozinka'] != null ? json['lozinka'] as String : null);
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "datumRodjenja":
            datumRodjenja == null ? null : datumRodjenja!.toIso8601String(),
        "lozinkaHash": lozinkaHash,
        "lozinkaSalt": lozinkaSalt,
        "lozinka": lozinka,
      };
}
