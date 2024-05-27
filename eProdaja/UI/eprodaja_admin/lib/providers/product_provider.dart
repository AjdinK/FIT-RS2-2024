import 'dart:async';
import 'dart:convert';
import 'package:eprodaja_admin/providers/auth_provider.dart';
import 'package:http/http.dart';
import 'package:http/http.dart' as http;

class ProductProvider {
  static String? _baseUrl;

  ProductProvider() {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "http://localhost:5151/");
  }
  //http://localhost:5151/Proizvodi/GetAll

  Future<dynamic> GetAll() async {
    // var url = "${_baseUrl}/Proizvodi/GetAll";
    var url = "http://localhost:5151/Proizvodi/GetAll";
    var uri = Uri.parse(url);

    var response = await http.get(uri, headers: createHeader());

    if (isResponseValid(response)) {
      var data = json.decode(response.body);
      return data;
    } else {
      throw Exception("Error while getting data, check logs ");
    }
  }

  bool isResponseValid(Response response) {
    if (response.statusCode < 299) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Error check again later");
    }
  }

  Map<String, String> createHeader() {
    var username = AuthProvider.username ?? "";
    var password = AuthProvider.password ?? "";

    var basicAuth = "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    return headers;
  }
}
