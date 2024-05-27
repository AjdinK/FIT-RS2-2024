import 'package:eprodaja_admin_moje/screens/korisnici_screen.dart';
import 'package:eprodaja_admin_moje/screens/login_sreen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  MasterScreen(this.child, this.title, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              onTap: () {
                Navigator.of(context).pop();
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => LoginSreen(),
                  ),
                );
              },
              leading: const Icon(Icons.arrow_back),
              title: const Text('Back'),
            ),
            ListTile(
              onTap: () {
                Navigator.of(context).pop();
              },
              leading: const Icon(Icons.info_outline),
              title: const Text('Detalji'),
            ),
            ListTile(
              onTap: () {
                Navigator.of(context).pop();
              },
              leading: const Icon(Icons.store_outlined),
              title: const Text('Product'),
            ),
            ListTile(
              onTap: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => const KorisniciScreen(),
                  ),
                );
              },
              leading: const Icon(Icons.people_alt_outlined),
              title: const Text('Korisnici'),
            ),
          ],
        ),
      ),
      body: widget.child,
    );
  }
}
