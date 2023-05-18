import 'package:json_annotation/json_annotation.dart';

part 'Cjenovnik.g.dart';

@JsonSerializable()
class Cjenovnik {
  int? cjenovnikId;
  String? zona;
  String? vrstaKarte;
  String? tipKarte;
  String? odrediste;
  String? polaziste;
  String? cijenaPrikaz;
  int? cijena;

  Cjenovnik() {}
  factory Cjenovnik.fromJson(Map<String, dynamic> json) =>
      _$CjenovnikFromJson(json);

  /// Connect the generated [_$CjenovnikToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CjenovnikToJson(this);
}
