import 'base_provider.dart';
import '../models/karta/Karta.dart';

class KartaProvider extends BaseProvider<Karta> {
  KartaProvider() : super("Karta");

  @override
  Karta fromJson(data) {
    return Karta.fromJson(data);
  }
}
