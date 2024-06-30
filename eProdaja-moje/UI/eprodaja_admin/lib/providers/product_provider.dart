import 'dart:convert';

import 'package:eprodaja_admin/providers/auth_provider.dart';
import 'package:http/http.dart' as http;

class ProductProvider {
  static String? _baseUrl;

  ProductProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "http://localhost:5269/");
    //http://localhost:5269/Proizvodi
    //defaultValue: "http://10.0.2.2:5269/");
  }

  Future<dynamic> get() async {
    var url = "${_baseUrl}Proizvodi";
    var uri = Uri.parse(url);

    var response = await http.get(uri, headers: CreateHeaders());

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Unknown exception");
    }
  }

  bool isValidResponse(http.Response response) {
    if (response.statusCode <= 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception('Unauthorized');
    } else {
      throw Exception('Error while fetching data');
    }
  }

  Map<String, String> CreateHeaders() {
    var username = AuthProvider.username;
    var password = AuthProvider.password;

    var basicAuth = "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var header = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    return header;
  }
}
