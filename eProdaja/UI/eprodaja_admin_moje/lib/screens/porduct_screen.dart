import 'package:eprodaja_admin_moje/layouts/master_screen.dart';
import 'package:eprodaja_admin_moje/models/proizvod.dart';
import 'package:eprodaja_admin_moje/models/search_result.dart';
import 'package:eprodaja_admin_moje/providers/product_provider.dart';
import 'package:eprodaja_admin_moje/providers/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class PorductScreen extends StatefulWidget {
  PorductScreen({super.key});

  @override
  State<PorductScreen> createState() => _PorductScreenState();
}

class _PorductScreenState extends State<PorductScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      Column(
        children: [
          _buildSearch(),
          _buildResultView(),
        ],
      ),
      "Proizvodi",
    );
  }

  TextEditingController? searchNaziv = TextEditingController();
  TextEditingController? searchSifra = TextEditingController();
  SearchResult<Proizvod>? result;

  late ProductProvider provider;
  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    provider = context.read<ProductProvider>();
  }

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(25),
      child: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                SizedBox(
                  width: 300,
                  child: TextField(
                    controller: searchNaziv,
                    decoration: const InputDecoration(
                      hintText: "search naziv ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                const SizedBox(
                  width: 20,
                ),
                SizedBox(
                  width: 300,
                  child: TextField(
                    controller: searchSifra,
                    decoration: const InputDecoration(
                      hintText: "search sifra ..",
                      border: OutlineInputBorder(),
                    ),
                  ),
                ),
                const SizedBox(
                  width: 20,
                ),
                ElevatedButton(
                  onPressed: () async {
                    var filter = {
                      'naziv': searchNaziv?.text,
                      'sifra': searchSifra?.text
                    };

                    result = await provider.get(filter: filter);
                    setState(() {});
                  },
                  child: const Text("Search"),
                )
              ],
            )
          ],
        ),
      ),
    );
  }

  Widget _buildResultView() {
    return Padding(
      padding: const EdgeInsets.all(100),
      child: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          color: Colors.grey.shade100,
          borderRadius: BorderRadius.circular(6),
        ),
        child: SingleChildScrollView(
          child: DataTable(
            columns: const [
              DataColumn(
                label: Text("ID"),
              ),
              DataColumn(
                label: Text("Naziv"),
              ),
              DataColumn(
                label: Text("Sifra"),
              ),
              DataColumn(
                label: Text("Cijena"),
              ),
              DataColumn(
                label: Text("Slika"),
              ),
              DataColumn(
                label: Text("Akcije"),
              ),
            ],
            rows: result?.resultList
                    .map(
                      (e) => DataRow(
                        cells: [
                          DataCell(
                            Text(
                              e.proizvodId.toString(),
                            ),
                          ),
                          DataCell(
                            Text(e.naziv ?? ""),
                          ),
                          DataCell(
                            Text(e.sifra ?? ""),
                          ),
                          DataCell(
                            Text(
                              formatNumber(e.cijena),
                            ),
                          ),
                          DataCell(
                            e.slika != null
                                ? SizedBox(
                                    width: 100,
                                    height: 100,
                                    child: imageFromString(e.slika!),
                                  )
                                : const Text(""),
                          ),
                          DataCell(Row(
                            children: [
                              TextButton(
                                onPressed: () {},
                                child: const Text(
                                  "Edit",
                                  style: TextStyle(
                                    color: Colors.blue,
                                  ),
                                ),
                              ),
                              TextButton(
                                onPressed: () {},
                                child: const Text(
                                  "Delete",
                                  style: TextStyle(color: Colors.red),
                                ),
                              )
                            ],
                          )),
                        ],
                      ),
                    )
                    .toList()
                    .cast<DataRow>() ??
                [],
          ),
        ),
      ),
    );
  }
}
