import 'package:json_annotation/json_annotation.dart';

part 'Karta.g.dart';

@JsonSerializable()
class Karta {
  int? kartaId;
  String? nacinPlacanja;
  String? vrstaKarte;
  String? tipKarte;
  String? odrediste;
  String? polaziste;
  String? cijenaPrikaz;
  String? imePrezimeKupca;
  String? relacija;
  DateTime? datumVadjenjaKarte;
  DateTime? datumVazenjaKarte;

  Karta() {}
  factory Karta.fromJson(Map<String, dynamic> json) => _$KartaFromJson(json);

  /// Connect the generated [_$KartaToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$KartaToJson(this);
}
