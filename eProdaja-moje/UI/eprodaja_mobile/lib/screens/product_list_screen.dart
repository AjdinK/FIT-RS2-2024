import 'package:eprodaja_mobile/layouts/master_screen.dart';
import 'package:eprodaja_mobile/models/proizvod.dart';
import 'package:eprodaja_mobile/models/search_result.dart';
import 'package:eprodaja_mobile/providers/product_provider.dart';
import 'package:eprodaja_mobile/providers/utils.dart';
import 'package:eprodaja_mobile/screens/product_details_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../providers/cart_provider.dart';

class ProductListScreen extends StatefulWidget {
  static const String routeName = "/product";

  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  ProductProvider? _productProvider = null;
  CartProvider? _cartProvider = null;
  SearchResult<Proizvod>? data = null;
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _cartProvider = context.read<CartProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _productProvider?.get();
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Proizvodi",
        SingleChildScrollView(
          child: Container(
            child: Column(
              children: [
                _buildProductSearch(),
                Container(
                  height: 500,
                  child: GridView(
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        childAspectRatio: 4 / 3,
                        crossAxisSpacing: 10,
                        mainAxisSpacing: 30),
                    scrollDirection: Axis.horizontal,
                    children: _buildProductCardList(),
                  ),
                )
              ],
            ),
          ),
        ));
  }

  Widget _buildProductSearch() {
    return Row(
      children: [
        Expanded(
            child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: TextField(
            controller: _searchController,
            onSubmitted: (value) async {
              var tmpData = await _productProvider
                  ?.get(filter: {'fts': _searchController.text});
              setState(() {
                data = tmpData!;
              });
            },
            decoration: InputDecoration(
                hintText: "Search", prefixIcon: Icon(Icons.search)),
          ),
        )),
        Container(
          padding: EdgeInsets.symmetric(vertical: 8, horizontal: 8),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            onPressed: () async {
              print('called product');
              var tmpData = await _productProvider
                  ?.get(filter: {'fts': _searchController.text});
              setState(() {
                data = tmpData!;
              });
            },
          ),
        )
      ],
    );
  }

  List<Widget> _buildProductCardList() {
    if (data?.result?.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data!.result
        .map((x) => Container(
              child: Column(
                children: [
                  Container(
                    height: 100,
                    width: 100,
                    child: x.slika == null
                        ? Placeholder()
                        : imageFromString(x.slika!),
                  ),
                  Text(x.naziv ?? ""),
                  Text(formatNumber(x.cijena)),
                  IconButton(
                      onPressed: () {
                        _cartProvider?.addToCart(x);
                      },
                      icon: Icon(Icons.shopping_cart))
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
