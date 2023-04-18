import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../models/cjenovnik/Cjenovnik.dart';
import 'base_provider.dart';

class CjenovnikProvider extends BaseProvider<Cjenovnik> {
  CjenovnikProvider() : super("Cjenovnik");

  @override
  Cjenovnik fromJson(data) {
    return Cjenovnik.fromJson(data);
  }
}
