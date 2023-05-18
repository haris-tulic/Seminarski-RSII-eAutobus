class Stanica {
  int? stanicaID;
  String? nazivLokacijestanice;
  Stanica({this.stanicaID, this.nazivLokacijestanice});

  factory Stanica.fromJson(Map<String, dynamic> json) {
    return Stanica(
      stanicaID: json['stanicaID'] as int,
      nazivLokacijestanice: json['nazivLokacijeStanice'] as String,
    );
  }
  Map<String, dynamic> toJson() => {
        "stanicaID": stanicaID,
        "nazivLokacijeStanice": nazivLokacijestanice,
      };
  bool operator ==(dynamic other) =>
      other != null && other is Stanica && this.stanicaID == other.stanicaID;

  @override
  int get hashCode => super.hashCode;
}
