// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vrsta_proizvoda.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

VrstaProizvoda _$VrstaProizvodaFromJson(Map<String, dynamic> json) =>
    VrstaProizvoda()
      ..vrstaId = (json['vrstaId'] as num?)?.toInt()
      ..naziv = json['naziv'] as String?;

Map<String, dynamic> _$VrstaProizvodaToJson(VrstaProizvoda instance) =>
    <String, dynamic>{
      'vrstaId': instance.vrstaId,
      'naziv': instance.naziv,
    };
