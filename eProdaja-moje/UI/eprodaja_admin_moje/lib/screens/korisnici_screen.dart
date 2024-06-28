import 'package:eprodaja_admin_moje/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class KorisniciScreen extends StatelessWidget {
  const KorisniciScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        Scaffold(
          appBar: AppBar(
            backgroundColor: Colors.grey.shade100,
          ),
        ),
        "Korisnici");
  }
}
