// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Karta.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Karta _$KartaFromJson(Map<String, dynamic> json) => Karta()
  ..kartaId = json['kartaId'] as int?
  ..nacinPlacanja = json['nacinPlacanja'] as String?
  ..vrstaKarte = json['vrstaKarte'] as String?
  ..tipKarte = json['tipKarte'] as String?
  ..odrediste = json['odrediste'] as String?
  ..polaziste = json['polaziste'] as String?
  ..cijenaPrikaz = json['cijenaPrikaz'] as String?
  ..relacija = json['relacija'] as String?
  ..datumVadjenjaKarte = json['datumVadjenjaKarte'] as DateTime
  ..datumVazenjaKarte = json['datumVazenjaKarte'] as DateTime;

Map<String, dynamic> _$KartaToJson(Karta instance) => <String, dynamic>{
      'kartaId': instance.kartaId,
      'nacinPlacanja': instance.nacinPlacanja,
      'vrstaKarte': instance.vrstaKarte,
      'tipKarte': instance.tipKarte,
      'odrediste': instance.odrediste,
      'polaziste': instance.polaziste,
      'cijenaPrikaz': instance.cijenaPrikaz,
      'relacija': instance.relacija,
      'datumVadjenjaKarte': instance.datumVadjenjaKarte,
      'datumVazenjaKarte': instance.datumVazenjaKarte
    };
