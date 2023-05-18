import 'package:eautobusmobile/models/redvoznje/Stanica.dart';
import 'package:eautobusmobile/providers/base_provider.dart';

class StanicaProvider extends BaseProvider<Stanica> {
  StanicaProvider() : super("Stanica");

  @override
  Stanica fromJson(data) {
    return Stanica.fromJson(data);
  }
}
