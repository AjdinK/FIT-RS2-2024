
import 'package:eprodaja_mobile/models/order.dart';
import 'package:eprodaja_mobile/providers/base_provider.dart';

class OrderProvider extends BaseProvider<Order> {
  OrderProvider() : super("Narudzbe");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Order();
  }
}