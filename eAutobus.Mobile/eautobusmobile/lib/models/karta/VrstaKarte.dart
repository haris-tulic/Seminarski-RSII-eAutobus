class VrstaKarte {
  int? vrstaKarteID;
  String? naziv;

  VrstaKarte({this.vrstaKarteID, this.naziv});

  factory VrstaKarte.fromJson(Map<String, dynamic> json) {
    return VrstaKarte(
      vrstaKarteID: json['vrstaKarteID'] as int,
      naziv: json['naziv'] as String,
    );
  }
  Map<String, dynamic> toJson() =>
      {"vrstaKarteID": vrstaKarteID, "naziv": naziv};
}
