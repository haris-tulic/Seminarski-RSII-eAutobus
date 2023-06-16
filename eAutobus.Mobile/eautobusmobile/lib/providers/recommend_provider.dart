import 'package:eautobusmobile/models/redvoznje/RedVoznje.dart';
import 'package:eautobusmobile/providers/base_provider.dart';

class RecommendProvider extends BaseProvider<RedVoznje> {
  RecommendProvider() : super("Preporuke");
  @override
  RedVoznje fromJson(data) {
    return RedVoznje.fromJson(data);
  }
}
