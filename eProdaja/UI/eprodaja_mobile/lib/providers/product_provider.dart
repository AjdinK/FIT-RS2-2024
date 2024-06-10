import 'dart:convert';
import 'package:eprodaja_mobile/models/proizvod.dart';
import 'package:eprodaja_mobile/models/search_result.dart';
import 'package:eprodaja_mobile/providers/auth_provider.dart';
import 'package:eprodaja_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class ProductProvider extends BaseProvider<Proizvod> {
  ProductProvider(): super("Proizvodi");

  @override
  Proizvod fromJson(data) {
    return Proizvod.fromJson(data);
  }
}