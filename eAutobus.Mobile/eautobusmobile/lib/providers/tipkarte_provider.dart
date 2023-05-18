import 'package:eautobusmobile/models/karta/TipKarte.dart';
import 'package:eautobusmobile/providers/base_provider.dart';

class TipKarteProvider extends BaseProvider<TipKarte> {
  TipKarteProvider() : super("TipKarte");
  @override
  TipKarte fromJson(data) {
    return TipKarte.fromJson(data);
  }
}
