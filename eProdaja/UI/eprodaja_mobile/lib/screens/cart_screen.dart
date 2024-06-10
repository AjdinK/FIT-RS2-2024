import 'package:eprodaja_mobile/layouts/master_screen.dart';
import 'package:eprodaja_mobile/models/cart.dart';
import 'package:eprodaja_mobile/providers/cart_provider.dart';
import 'package:eprodaja_mobile/providers/utils.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../providers/order_provider.dart';


class CartScreen extends StatefulWidget {
  static const String routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {

  late CartProvider _cartProvider;
  late OrderProvider _orderProvider;
  
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
    _orderProvider = context.read<OrderProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen("Cart",
         Column(
          children: [
            Expanded(child: _buildProductCardList()),
            _buildBuyButton()
          ],
        ),
      );
  }

  Widget _buildProductCardList() {
      return Container(
        
        child: ListView.builder(
          itemCount: _cartProvider?.cart.items.length,
          itemBuilder: (context, index) {
            print("rendering element");
            return _buildProductCard(_cartProvider.cart.items[index]);
          },
        ),
      );
  }

  ListTile _buildProductCard(CartItem item) {
    return ListTile(
      leading: item.product.slika == null ? Placeholder(): imageFromString(item.product.slika!),
      title: Text(item.product.naziv ?? ""),
      subtitle: Text(item.product.cijena.toString()),
      trailing: Text(item.count.toString()),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(onPressed: () {
        List<Map> items = [];
        _cartProvider.cart.items.forEach((item) {
          items.add({
            "proizvodId": item.product.proizvodId,
            "kolicina": item.count
          });
        });

        var order = {
            "items": items
        };

        //_orderProvider.insert(order)

    }, child: Text("Buy"));
  }

 
}