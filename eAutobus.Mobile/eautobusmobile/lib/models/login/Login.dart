class Login {
  int? korisnikId;
  String? korisnickoIme;
  String? ime;
  String? prezime;
  String? email;

  Login({
    this.korisnikId,
    this.korisnickoIme,
    this.ime,
    this.prezime,
    this.email,
  });
  factory Login.fromJson(Map<String, dynamic> json) {
    return Login(
        korisnikId: json['korisnikID'] as int,
        korisnickoIme: json['korisnickoIme'] as String,
        ime: json['ime'] as String,
        prezime: json['prezime'] as String,
        email: json['email'] as String?);
  }
  Map<String, dynamic> toJson() => {
        "korisnikId": korisnikId,
        "korisnickoIme": korisnickoIme,
        "ime": ime,
        "prezime": prezime,
        "email": email
      };
}
