class KartaKupac {
  int? kupacID;
  String? imePrezimeKupca;
  int? kartaID;
  bool? aktivna;
  String? karta;
  DateTime? datumVadjenjaKarte;
  DateTime? datumVazenjaKarte;
  String? pravacS;
  String? polaziste;
  String? odrediste;

  KartaKupac(
      {this.aktivna,
      this.imePrezimeKupca,
      this.datumVadjenjaKarte,
      this.karta,
      this.datumVazenjaKarte,
      this.kartaID,
      this.kupacID,
      this.odrediste,
      this.polaziste,
      this.pravacS});

  factory KartaKupac.fromJson(Map<String, dynamic> json) {
    return KartaKupac(
      kupacID: json['kupacID'] as int,
      imePrezimeKupca: json['kupac'] as String,
      karta: json['karta'] as String,
      kartaID: json['kartaID'] as int,
      aktivna: json['aktivna'] as bool,
      datumVadjenjaKarte: DateTime.parse(json['datumVadjenjaKarte'] as String),
      datumVazenjaKarte: DateTime.parse(json['datumVazenjaKarte'] as String),
      pravacS: json['pravacS'] as String,
      polaziste: json['polaziste'] as String,
      odrediste: json['odrediste'] as String,
    );
  }
  Map<String, dynamic> toJson() => {
        "kupacID": kupacID,
        "kupac": imePrezimeKupca,
        "karta": karta,
        "kartaID": kartaID,
        "aktivna": aktivna,
        "datumVadjenjaKarte": datumVadjenjaKarte,
        "datumVazenjaKarte": datumVazenjaKarte,
        "pravacS": pravacS,
        "polaziste": polaziste,
        "odrediste": odrediste,
      };
}
