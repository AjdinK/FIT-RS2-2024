import 'package:eprodaja_admin/screens/master_screen.dart';
import 'package:flutter/material.dart';

class ProductListScreen extends StatelessWidget {
  const ProductListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Proizvodi",
      const Center(
        child: Column(
          children: [
            Text("test"),
          ],
        ),
      ),
    );
  }
}
