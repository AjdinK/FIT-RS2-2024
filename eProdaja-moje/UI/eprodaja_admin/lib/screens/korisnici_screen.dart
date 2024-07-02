import 'package:eprodaja_admin/screens/master_screen.dart';
import 'package:flutter/material.dart';

class KorisniciScreen extends StatelessWidget {
  const KorisniciScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Korisnici",
        const Center(
          child: Column(
            children: [
              Text("Korisnici Screen"),
            ],
          ),
        ));
  }
}
