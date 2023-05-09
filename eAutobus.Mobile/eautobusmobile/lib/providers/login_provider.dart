import 'package:eautobusmobile/providers/base_provider.dart';

import '../models/login/Login.dart';

class LoginProvider extends BaseProvider<Login> {
  LoginProvider() : super("Login");
  @override
  Login fromJson(data) {
    return Login.fromJson(data);
  }
}
