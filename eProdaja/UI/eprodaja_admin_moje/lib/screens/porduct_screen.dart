import 'package:eprodaja_admin_moje/layouts/master_screen.dart';
import 'package:eprodaja_admin_moje/models/proizvod.dart';
import 'package:eprodaja_admin_moje/models/search_result.dart';
import 'package:eprodaja_admin_moje/providers/product_provider.dart';
import 'package:eprodaja_admin_moje/providers/util.dart';
import 'package:flutter/material.dart';

class PorductScreen extends StatefulWidget {
  PorductScreen({super.key});

  @override
  State<PorductScreen> createState() => _PorductScreenState();
}

class _PorductScreenState extends State<PorductScreen> {
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

  TextEditingController? searchNaziv = TextEditingController();
  TextEditingController? searchSifra = TextEditingController();
  SearchResult<Proizvod>? result;
  ProductProvider productProvider = ProductProvider();

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
                  child: TextField(
                    controller: searchNaziv,
                    decoration: const InputDecoration(
                      hintText: "search naziv ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                Container(
                  width: 300,
                  child: TextField(
                    controller: searchSifra,
                    decoration: const InputDecoration(
                      hintText: "search sifra ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                ElevatedButton(
                  onPressed: () async {
                    var filter = {
                      'naziv': searchNaziv?.text,
                      'sifra': searchSifra?.text
                    };

                    result = await productProvider.get(filter: filter);
                    setState(() {});
                  },
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
    return Expanded(
      child: SingleChildScrollView(
        child: DataTable(
          columns: const [
            DataColumn(label: Text("ID"), numeric: true),
            DataColumn(label: Text("Naziv")),
            DataColumn(label: Text("Šifra")),
            DataColumn(label: Text("Cijena")),
            DataColumn(label: Text("Slika")),
          ],
          rows: result?.resultList
                  .map(
                    (e) => DataRow(
                      cells: [
                        DataCell(Text(e.proizvodId.toString())),
                        DataCell(Text(e.naziv ?? "")),
                        DataCell(Text(e.sifra ?? "")),
                        DataCell(Text(formatNumber(e.cijena))),
                        DataCell(
                          e.slika != null
                              ? Container(
                                  width: 100,
                                  height: 100,
                                  child: imageFromString(e.slika!),
                                )
                              : const Text(""),
                        ),
                      ],
                    ),
                  )
                  .toList()
                  .cast<DataRow>() ??
              [], // Convert Iterable to List
        ),
      ),
    );
  }
}
