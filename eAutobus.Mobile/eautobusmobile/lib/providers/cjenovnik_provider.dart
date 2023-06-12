import '../models/cjenovnik/Cjenovnik.dart';
import 'base_provider.dart';

class CjenovnikProvider extends BaseProvider<Cjenovnik> {
  CjenovnikProvider() : super("Cjenovnik");

  @override
  Cjenovnik fromJson(data) {
    return Cjenovnik.fromJson(data);
  }
}
