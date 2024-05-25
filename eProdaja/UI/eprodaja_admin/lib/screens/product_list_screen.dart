import 'package:eprodaja_admin/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class ProductListScreen extends StatelessWidget {
  const ProductListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen("Lista proizvoda", Column(
      children: [
        Text("Lista proizvoda placeholder"),
        SizedBox(height: 8,),
        ElevatedButton(onPressed: () {
          Navigator.pop(context);
        }, child: Text("Nazad"))
      ],
    ));
  }
}