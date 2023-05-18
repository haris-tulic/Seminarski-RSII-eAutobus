import '../karta/KartaKupac.dart';

class Korisnik {
  int? kupacID;
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;
  String? brojTelefona;
  String? adresaStanovanja;
  List<KartaKupac>? karte;

  Korisnik(
      {this.kupacID,
      this.korisnickoIme,
      this.ime,
      this.prezime,
      this.email,
      this.brojTelefona,
      this.adresaStanovanja,
      this.karte});

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
        kupacID: json['kupacID'] as int,
        korisnickoIme: json['korisnickoIme'] as String,
        ime: json['ime'] as String,
        prezime: json['prezime'] as String,
        email: json['email'] as String,
        brojTelefona: json['brojTelefona'] as String,
        adresaStanovanja: json['adresaStanovanja'],
        karte: (json['kartaKupacs'] as List<dynamic>?)
            ?.map((e) => KartaKupac.fromJson(e as Map<String, dynamic>))
            .toList());
  }

  Map<String, dynamic> toJson() => {
        "kupacID": kupacID,
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "brojTelefona": brojTelefona,
        "karte": karte,
        "adresaStanovanja": adresaStanovanja,
      };
}
