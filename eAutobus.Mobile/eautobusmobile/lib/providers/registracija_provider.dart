import '../models/korisnik/Korisnik.dart';
import 'base_provider.dart';

class RegistracijaProvider extends BaseProvider<Korisnik> {
  RegistracijaProvider() : super("Kupac/Registracija");

  @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik.fromJson(data);
  }
}
