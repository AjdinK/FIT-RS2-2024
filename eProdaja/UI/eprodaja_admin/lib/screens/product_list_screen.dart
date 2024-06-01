import 'package:eprodaja_admin/layouts/master_screen.dart';
import 'package:eprodaja_admin/models/proizvod.dart';
import 'package:eprodaja_admin/models/search_result.dart';
import 'package:eprodaja_admin/providers/product_provider.dart';
import 'package:eprodaja_admin/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({super.key});

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  late ProductProvider provider;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

    provider = context.read<ProductProvider>();
  }

  SearchResult<Proizvod>? result = null;
  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Lista proizvoda",
        Container(
          child: Column(
            children: [_buildSearch(), _buildResultView()],
          ),
        ));
  }

  TextEditingController _ftsEditingController = TextEditingController();
  TextEditingController _sifraController = TextEditingController();

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(9.0),
      child: Row(
        children: [
          Expanded(
              child: TextField(
            controller: _ftsEditingController,
            decoration: const InputDecoration(labelText: "Naziv ili sifra"),
          )),
          const SizedBox(
            width: 8,
          ),
          Expanded(
              child: TextField(
            controller: _sifraController,
            decoration: const InputDecoration(labelText: "Šifra"),
          )),
          ElevatedButton(
            onPressed: () async {
              var filter = {
                'fts': _ftsEditingController.text,
                'sifra': _sifraController.text
              };

              result = await provider.get(filter: filter);

              setState(() {});

              //TODO: add call to API
            },
            child: const Text("Pretraga"),
          ),
          const SizedBox(
            width: 8,
          ),
          ElevatedButton(
              onPressed: () async {
                //TODO: add call to API
              },
              child: const Text("Dodaj"))
        ],
      ),
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: DataTable(
          columns: [
            const DataColumn(label: Text("ID"), numeric: true),
            const DataColumn(label: Text("Naziv")),
            const DataColumn(label: Text("Šifra")),
            const DataColumn(label: Text("Cijena")),
            const DataColumn(label: Text("Slika")),
          ],
          rows: result?.result
                  .map((e) => DataRow(cells: [
                        DataCell(Text(e.proizvodId.toString())),
                        DataCell(Text(e.naziv ?? "")),
                        DataCell(Text(e.sifra ?? "")),
                        DataCell(Text(formatNumber(e.cijena))),
                        DataCell(e.slika != null
                            ? Container(
                                width: 100,
                                height: 100,
                                child: imageFromString(e.slika!),
                              )
                            : const Text("")),
                      ]))
                  .toList()
                  .cast<DataRow>() ??
              [], // Convert Iterable to List
        ),
      ),
    );
  }
}

// rows: [
//             DataRow(cells:  [DataCell(Container(child: Text("1"), width: double.infinity,)), DataCell(Container(child: Text("Laptop"), width: double.infinity,))]),
//             DataRow(cells:  [DataCell(Container(child: Text("1"), width: double.infinity,)), DataCell(Container(child: Text("Laptop"), width: double.infinity,))]),
//           ]
