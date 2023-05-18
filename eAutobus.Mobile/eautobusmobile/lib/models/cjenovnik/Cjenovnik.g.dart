// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Cjenovnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Cjenovnik _$CjenovnikFromJson(Map<String, dynamic> json) => Cjenovnik()
  ..cjenovnikId = json['cjenovnikId'] as int?
  ..zona = json['zona'] as String?
  ..vrstaKarte = json['vrstaKarte'] as String?
  ..tipKarte = json['tipKarte'] as String?
  ..odrediste = json['odrediste'] as String?
  ..polaziste = json['polaziste'] as String?
  ..cijenaPrikaz = json['cijenaPrikaz'] as String?
  ..cijena = json['cijena'] as int?;

Map<String, dynamic> _$CjenovnikToJson(Cjenovnik instance) => <String, dynamic>{
      'cjenovnikId': instance.cjenovnikId,
      'zona': instance.zona,
      'vrstaKarte': instance.vrstaKarte,
      'tipKarte': instance.tipKarte,
      'odrediste': instance.odrediste,
      'polaziste': instance.polaziste,
      'cijenaPrikaz': instance.cijenaPrikaz,
      'cijena': instance.cijena,
    };
