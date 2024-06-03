import 'package:eprodaja_admin_moje/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class PorductScreen extends StatelessWidget {
  const PorductScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      Container(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView(),
          ],
        ),
      ),
      "Proizvodi",
    );
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(25),
      child: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Container(
                  width: 300,
                  child: const TextField(
                    decoration: InputDecoration(
                      hintText: "search naziv ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                Container(
                  width: 300,
                  child: const TextField(
                    decoration: InputDecoration(
                      hintText: "search sifra ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                ElevatedButton(
                  onPressed: () {},
                  child: const Text("Search"),
                ),
                ElevatedButton(
                  onPressed: () {},
                  child: const Text("Add new"),
                )
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget _buildResultView() {
    return Placeholder();
  }
}
