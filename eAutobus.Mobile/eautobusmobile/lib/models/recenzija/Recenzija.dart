class Recenzija {
  String? komentar;
  String? linija;
  int? rasporedVoznjeID;
  int? ocjena;
  DateTime? datumRecenzije;
  String? vrstaUsluga;
  int? kupacID;
  Recenzija(
      {this.komentar,
      this.linija,
      this.ocjena,
      this.datumRecenzije,
      this.rasporedVoznjeID,
      this.vrstaUsluga,
      this.kupacID});

  factory Recenzija.fromJson(Map<String, dynamic> json) {
    return Recenzija(
      komentar: json['komentar'] as String,
      linija: json['rasporedVoznje'] == null
          ? null
          : json['rasporedVoznje'] as String?,
      rasporedVoznjeID: json['rasporedVoznjeID'] as int,
      kupacID: json['kupacID'] as int,
      ocjena: json['ocjena'] as int,
      datumRecenzije: DateTime.parse(json['datumRecenzije'].toString()),
      vrstaUsluga: json['vrstaUsluga'] as String,
    );
  }
  Map<String, dynamic> toJson() => {
        'komentar': komentar,
        'rasporedVoznje': linija,
        "ocjena": ocjena,
        'datumRecenzije': datumRecenzije?.toIso8601String(),
        'raspoderVoznjeID': rasporedVoznjeID,
        'vrstaUsluga': vrstaUsluga,
        'kupacID': kupacID,
      };
}
