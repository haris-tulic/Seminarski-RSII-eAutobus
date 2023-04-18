import 'package:json_annotation/json_annotation.dart';

part 'RedVoznje.g.dart';

@JsonSerializable()
class RedVoznje {
  int? rasporedVoznjeId;
  int? brojLinije;
  int? brojAutobusa;
  String? vozacIme;
  String? polazak;
  String? odlazak;
  String? nazivLinije;
  DateTime? vrijemePolaska;
  DateTime? vrijemeDolaska;
  DateTime? datum;
  String? cijenaPrikaz;

  RedVoznje() {}
  factory RedVoznje.fromJson(Map<String, dynamic> json) =>
      _$RedVoznjeFromJson(json);

  /// Connect the generated [_$RedVoznjeToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RedVoznjeToJson(this);
}
