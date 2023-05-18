import 'dart:core';

import 'package:json_annotation/json_annotation.dart';

part 'Karta.g.dart';

@JsonSerializable()
class Karta {
  int? kartaId;
  String? nacinPlacanja;
  int? vrstaKarteID;
  int? tipKarteID;
  int? odredisteID;
  int? polazisteID;
  String? cijenaPrikaz;
  int? cijena;
  String? ime;
  String? prezime;
  DateTime? datumVadjenjaKarte;
  DateTime? datumVazenjaKarte;
  int? kupacID;
  String? korisnickoIme;

  Karta() {}
  factory Karta.fromJson(Map<String, dynamic> json) => _$KartaFromJson(json);

  /// Connect the generated [_$KartaToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$KartaToJson(this);
}
