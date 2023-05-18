// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Karta.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Karta _$KartaFromJson(Map<String, dynamic> json) => Karta()
  ..kartaId = json['kartaID'] as int?
  ..nacinPlacanja = json['nacinPlacanja'] as String?
  ..vrstaKarteID = json['vrstaKarteID'] as int?
  ..tipKarteID = json['tipKarteID'] as int?
  ..odredisteID = json['odredisteID'] as int?
  ..polazisteID = json['polazisteID'] as int?
  ..cijenaPrikaz = json['cijenaPrikaz'] as String?
  ..cijena = json['cijena'] as int?
  ..datumVadjenjaKarte = DateTime.parse(json['datumVadjenjaKarte'] as String)
  ..datumVazenjaKarte = DateTime.parse(json['datumVazenjaKarte'] as String)
  ..ime = json['ime'] as String?
  ..kupacID = json['kupacID'] as int?
  ..prezime = json['prezime'] as String?
  ..korisnickoIme =
      json['korisnickoIme'] == null ? null : json['korisnickoIme'] as String;

Map<String, dynamic> _$KartaToJson(Karta instance) => <String, dynamic>{
      'kartaID': instance.kartaId,
      'nacinPlacanja': instance.nacinPlacanja,
      'vrstaKarteID': instance.vrstaKarteID,
      'tipKarteID': instance.tipKarteID,
      'odredisteID': instance.odredisteID,
      'polazisteID': instance.polazisteID,
      'cijenaPrikaz': instance.cijenaPrikaz,
      'datumVadjenjaKarte': instance.datumVadjenjaKarte,
      'datumVazenjaKarte': instance.datumVazenjaKarte,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'cijena': instance.cijena,
      'kupacID': instance.kupacID,
      'korisnickoIme': instance.korisnickoIme,
    };
