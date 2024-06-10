import 'dart:convert';
import 'package:eprodaja_admin/models/jedinice_mjere.dart';
import 'package:eprodaja_admin/models/proizvod.dart';
import 'package:eprodaja_admin/models/search_result.dart';
import 'package:eprodaja_admin/models/vrsta_proizvoda.dart';
import 'package:eprodaja_admin/providers/auth_provider.dart';
import 'package:eprodaja_admin/providers/base_provider.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

class VrsteProizvodaProvider extends BaseProvider<VrstaProizvoda> {
  VrsteProizvodaProvider(): super("VrsteProizvodum");

  @override
  VrstaProizvoda fromJson(data) {
    return VrstaProizvoda.fromJson(data);
  }
}