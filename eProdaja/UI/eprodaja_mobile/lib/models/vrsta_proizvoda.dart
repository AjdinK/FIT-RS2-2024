

import 'package:json_annotation/json_annotation.dart';


part 'vrsta_proizvoda.g.dart';

@JsonSerializable()
class VrstaProizvoda {
  int? vrstaId;
  String? naziv;

  VrstaProizvoda();

  factory VrstaProizvoda.fromJson(Map<String, dynamic> json) => _$VrstaProizvodaFromJson(json);

    /// Connect the generated [_$PersonToJson] function to the `toJson` method.
    Map<String, dynamic> toJson() => _$VrstaProizvodaToJson(this);
}