

import 'package:json_annotation/json_annotation.dart';


part 'jedinice_mjere.g.dart';

@JsonSerializable()
class JediniceMjere {
  int? jedinicaMjereId;
  String? naziv;

  JediniceMjere();

    factory JediniceMjere.fromJson(Map<String, dynamic> json) => _$JediniceMjereFromJson(json);

    /// Connect the generated [_$PersonToJson] function to the `toJson` method.
    Map<String, dynamic> toJson() => _$JediniceMjereToJson(this);
}