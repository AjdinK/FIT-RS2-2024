import 'dart:convert';
import 'package:eprodaja_mobile/models/jedinice_mjere.dart';
import 'package:eprodaja_mobile/models/proizvod.dart';
import 'package:eprodaja_mobile/models/search_result.dart';
import 'package:eprodaja_mobile/providers/auth_provider.dart';
import 'package:eprodaja_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class JediniceMjereProvider extends BaseProvider<JediniceMjere> {
  JediniceMjereProvider(): super("JediniceMjere");

  @override
  JediniceMjere fromJson(data) {
    return JediniceMjere.fromJson(data);
  }
}