import 'package:flutter/material.dart';

class ProductListScreen extends StatelessWidget {
  const ProductListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Center(
          child: Text(
            "Product List Screen",
            style: TextStyle(
              fontSize: 17,
              fontStyle: FontStyle.italic,
            ),
          ),
        ),
      ),
      body: const Center(
        child: Text("Product List screen page"),
      ),
    );
  }
}
