// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'RedVoznje.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RedVoznje _$RedVoznjeFromJson(Map<String, dynamic> json) => RedVoznje()
  ..rasporedVoznjeId = json['rasporedVoznjeId'] as int?
  ..brojLinije = json['brojLinije'] as int?
  ..brojAutobusa = json['brojAutobusa'] as int?
  ..vozacIme = json['vozacIme'] as String?
  ..polazak = json['polazak'] as String?
  ..odlazak = json['odlazak'] as String?
  ..nazivLinije = json['nazivLinije'] as String?
  ..vrijemePolaska = json['vrijemePolaska'] as DateTime?
  ..vrijemeDolaska = json['vrijemeDolaska'] as DateTime?
  ..datum = json['datum'] as DateTime?
  ..cijenaPrikaz = json['cijenaPrikaz'] as String?;

Map<String, dynamic> _$RedVoznjeToJson(RedVoznje instance) => <String, dynamic>{
      'rasporedVoznjeId': instance.rasporedVoznjeId,
      'brojLinije': instance.brojLinije,
      'brojAutobusa': instance.brojAutobusa,
      'vozacIme': instance.vozacIme,
      'polazak': instance.polazak,
      'odlazak': instance.odlazak,
      'nazivLinije': instance.nazivLinije,
      'vrijemePolaska': instance.vrijemePolaska,
      'vrijemeDolaska': instance.vrijemeDolaska,
      'datum': instance.datum,
      'cijenaPrikaz': instance.cijenaPrikaz,
    };
