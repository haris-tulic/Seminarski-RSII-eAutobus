import '../models/korisnik/Korisnik.dart';
import 'base_provider.dart';

class KorisnikProvider extends BaseProvider<Korisnik> {
  KorisnikProvider() : super("Kupac");

  @override
  Korisnik fromJson(data) {
    // TODO: implement fromJson
    return Korisnik();
  }
}
