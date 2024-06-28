import 'package:eprodaja_admin_moje/models/proizvod.dart';
import 'package:eprodaja_admin_moje/providers/base_provider.dart';

class ProductProvider extends BaseProvider<Proizvod> {
  ProductProvider() : super("Proizvodi");

  @override
  Proizvod fromJson(data) {
    return Proizvod.fromJson(data);
  }
}
