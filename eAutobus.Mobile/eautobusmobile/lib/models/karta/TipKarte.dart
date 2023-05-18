class TipKarte {
  int? tipKarteID;
  String? naziv;

  TipKarte({this.tipKarteID, this.naziv});

  factory TipKarte.fromJson(Map<String, dynamic> json) {
    return TipKarte(
      tipKarteID: json['tipKarteID'] as int,
      naziv: json['naziv'] as String,
    );
  }
  Map<String, dynamic> toJson() => {"tipKarteID": tipKarteID, "naziv": naziv};
}
