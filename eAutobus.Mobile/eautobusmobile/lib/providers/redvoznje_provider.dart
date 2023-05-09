import 'base_provider.dart';
import '../models/redvoznje/RedVoznje.dart';

class RedVoznjeProvider extends BaseProvider<RedVoznje> {
  RedVoznjeProvider() : super("RasporedVoznje");

  @override
  RedVoznje fromJson(data) {
    return RedVoznje.fromJson(data);
  }
}
