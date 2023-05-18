import 'package:eautobusmobile/providers/base_provider.dart';
import '../models/karta/KartaKupac.dart';

class KartaKupacProvider extends BaseProvider<KartaKupac> {
  KartaKupacProvider() : super("KartaKupac");

  @override
  KartaKupac fromJson(data) {
    return KartaKupac.fromJson(data);
  }
}
