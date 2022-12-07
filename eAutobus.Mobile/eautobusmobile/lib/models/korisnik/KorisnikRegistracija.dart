class KorisnikRegistracijaRequest {
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? brojTelefona;
  String? email;
  String? adresaStanovanja;
  DateTime? datumRodjenja;
  String? lozinka;

  KorisnikRegistracijaRequest(
      {this.korisnickoIme,
      this.ime,
      this.prezime,
      this.email,
      this.datumRodjenja,
      this.lozinka});

  factory KorisnikRegistracijaRequest.fromJson(Map<String, dynamic> json) {
    return KorisnikRegistracijaRequest(
      korisnickoIme: json['korisnickoIme'] as String,
      ime: json['ime'] as String,
      prezime: json['prezime'] as String,
      email: json['prezime'] as String,
      datumRodjenja: DateTime.tryParse(json['datumRodjenja']),
      lozinka: json['lozinka'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "datumRodjenja":
            datumRodjenja == null ? null : datumRodjenja!.toIso8601String(),
        "lozinka": lozinka,
      };
}
