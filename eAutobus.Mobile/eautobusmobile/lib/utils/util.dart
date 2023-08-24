import 'dart:convert';
import 'dart:typed_data';

class Authorization {
  static String? username;
  static String? password;
}

Uint8List dataFromBase64String(String base64String) {
  return base64Decode(base64String);
}

String base64String(Uint8List data) {
  return base64Encode(data);
}
