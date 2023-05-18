import 'package:eautobusmobile/models/karta/VrstaKarte.dart';
import 'package:eautobusmobile/providers/base_provider.dart';

class VrstaKarteProvider extends BaseProvider<VrstaKarte> {
  VrstaKarteProvider() : super("VrstaKarte");

  @override
  VrstaKarte fromJson(data) {
    return VrstaKarte.fromJson(data);
  }
}
