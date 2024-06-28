import 'package:eprodaja_mobile/providers/cart_provider.dart';
import 'package:eprodaja_mobile/screens/cart_screen.dart';
import 'package:eprodaja_mobile/screens/product_details_screen.dart';
import 'package:eprodaja_mobile/screens/product_list_screen.dart';
import 'package:eprodaja_mobile/screens/user_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MasterScreen extends StatefulWidget {
  MasterScreen(this.title, this.child, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  CartProvider? _cartProvider;

  @override
  Widget build(BuildContext context) {
    _cartProvider = context.watch<CartProvider>();

    return Scaffold(
      appBar: AppBar(title: Text(widget.title),),
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              title: Text("Back"),
              onTap: () {
                Navigator.pop(context);
                Navigator.pop(context);
              },
            ),
             ListTile(
              title: Text("In cart ${_cartProvider?.cart.items.length}"),
              onTap: () {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(builder: (context) => CartScreen()));
              },
            ),
            ListTile(
              title: Text("Korisnici"),
              onTap: () {
                Navigator.of(context).pushReplacement(MaterialPageRoute(builder: (context) => UserListScreen()));
              },
            ),
            ListTile(
              title: Text("Proizvodi"),
              onTap: () {
                Navigator.of(context).push(MaterialPageRoute(builder: (context) => ProductListScreen()));
              },
            )
          ],
        ),
      ),
      body: widget.child ,
    );
  }
}