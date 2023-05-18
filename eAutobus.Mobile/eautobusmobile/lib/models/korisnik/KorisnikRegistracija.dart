class KorisnikRegistracijaRequest {
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? brojTelefona;
  String? email;
  String? adresaStanovanja;
  String? password;
  String? potvrdaPassworda;

  KorisnikRegistracijaRequest(
      {this.korisnickoIme,
      this.ime,
      this.prezime,
      this.email,
      this.potvrdaPassworda,
      this.password,
      this.brojTelefona,
      this.adresaStanovanja});

  factory KorisnikRegistracijaRequest.fromJson(Map<String, dynamic> json) {
    return KorisnikRegistracijaRequest(
      korisnickoIme: json['korisnickoIme'] as String,
      ime: json['ime'] as String,
      prezime: json['prezime'] as String,
      email: json['prezime'] as String,
      password: json['password'] as String,
      potvrdaPassworda: json['potvrdaPassworda'] as String,
      adresaStanovanja: json['adresaStanovanja'] as String,
      brojTelefona: json['brojTelefona'] as String,
    );
  }

  Map<String, dynamic> toJson() => {
        'korisnickoIme': korisnickoIme,
        'ime': ime,
        'prezime': prezime,
        'email': email,
        'potvrdaPassworda': potvrdaPassworda,
        'password': password,
        'brojTelefona': brojTelefona,
        'adresaStanovanja': adresaStanovanja,
      };
}
