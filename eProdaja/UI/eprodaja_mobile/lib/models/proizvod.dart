import 'package:json_annotation/json_annotation.dart';

part 'proizvod.g.dart';

@JsonSerializable()
class Proizvod {
  int? proizvodId;
  String? naziv;
  String? slika;
  String? sifra;
  double? cijena;
  int? vrstaId;
  int? jedinicaMjereId;

  Proizvod({this.proizvodId, this.naziv});

  /// Connect the generated [_$PersonFromJson] function to the `fromJson`
  /// factory.
  factory Proizvod.fromJson(Map<String, dynamic> json) =>
      _$ProizvodFromJson(json);

  /// Connect the generated [_$PersonToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ProizvodToJson(this);
}
