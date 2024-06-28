import 'package:eprodaja_admin/layouts/master_screen.dart';
import 'package:eprodaja_admin/models/proizvod.dart';
import 'package:eprodaja_admin/models/search_result.dart';
import 'package:eprodaja_admin/providers/product_provider.dart';
import 'package:eprodaja_admin/providers/utils.dart';
import 'package:eprodaja_admin/screens/product_details_screen.dart';
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
    return MasterScreen("Lista proizvoda",
      Container(
        child: Column(
          children: [
            _buildSearch(),
            _buildResultView()
          ],
        ),
      )
    );
  }

  TextEditingController _ftsEditingController = TextEditingController();
  TextEditingController _sifraController = TextEditingController();
  
  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(9.0),
      child: Row(
        children: [
          Expanded(child:  TextField(controller: _ftsEditingController, decoration: InputDecoration(labelText: "Naziv ili sifra"),)),
          SizedBox(width: 8,),
          Expanded(child:  TextField(controller: _sifraController,decoration: InputDecoration(labelText: "Šifra"),)),

          ElevatedButton(onPressed: () async {

          var filter = {
            'fts': _ftsEditingController.text,
            'sifra': _sifraController.text
          };
           result = await provider.get(filter: filter);
          
          setState(() {
          });

              //TODO: add call to API
          }, child: Text("Pretraga")),
          SizedBox(width: 8,),
          ElevatedButton(onPressed: () async {
            print("exec");
              Navigator.of(context).pushReplacement(MaterialPageRoute(builder: (context) => ProductDetailsScreen()));
          }, child: Text("Dodaj"))
        ],
      ),
    );
  }

  Widget _buildResultView() {
  return Expanded(
    child: Container(
      width: double.infinity,
      child: SingleChildScrollView(
      child: DataTable(
        columns: [
          DataColumn(label: Text("ID"), numeric: true),
          DataColumn(label: Text("Naziv")),
          DataColumn(label: Text("Šifra")),
          DataColumn(label: Text("Cijena")),
          DataColumn(label: Text("Slika")),
        ],
        rows: result?.result.map((e) => 
          DataRow(
            onSelectChanged: (selected) => {
              if (selected == true) {
                  Navigator.of(context).pushReplacement(MaterialPageRoute(builder: (context) => ProductDetailsScreen(product: e,)))
              }
              
            },
            cells: [
            DataCell(Text(e.proizvodId.toString())),
            DataCell(Text(e.naziv ?? "")),
            DataCell(Text(e.sifra ?? "")),
            DataCell(Text(formatNumber(e.cijena))),
            DataCell(e.slika != null ? Container(width: 100, height: 100,
                child: imageFromString(e.slika!),): Text("")),
          ])
        ).toList().cast<DataRow>() ?? [], // Convert Iterable to List
      ),
    ),
    ),
  );
}
}

// rows: [
//             DataRow(cells:  [DataCell(Container(child: Text("1"), width: double.infinity,)), DataCell(Container(child: Text("Laptop"), width: double.infinity,))]),
//             DataRow(cells:  [DataCell(Container(child: Text("1"), width: double.infinity,)), DataCell(Container(child: Text("Laptop"), width: double.infinity,))]),
//           ]