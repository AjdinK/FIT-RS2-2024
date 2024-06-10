import 'dart:convert';
import 'dart:io';

import 'package:eprodaja_admin/layouts/master_screen.dart';
import 'package:eprodaja_admin/models/jedinice_mjere.dart';
import 'package:eprodaja_admin/models/proizvod.dart';
import 'package:eprodaja_admin/models/search_result.dart';
import 'package:eprodaja_admin/models/vrsta_proizvoda.dart';
import 'package:eprodaja_admin/providers/jedenice_mjere_provider.dart';
import 'package:eprodaja_admin/providers/product_provider.dart';
import 'package:eprodaja_admin/providers/vrste_proizvoda_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class ProductDetailsScreen extends StatefulWidget {
  Proizvod? product;
  ProductDetailsScreen({super.key, this.product});

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {

  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late ProductProvider productProvider;
  late JediniceMjereProvider jediniceMjereProvider;
  late VrsteProizvodaProvider vrsteProizvodaProvider;
  SearchResult<VrstaProizvoda>? vrstaProizvodaResult;
  SearchResult<JediniceMjere>? jediniceMjereResult;
  bool isLoading = true;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

  }

  @override
  void initState() {

    productProvider = context.read<ProductProvider>();
    jediniceMjereProvider = context.read<JediniceMjereProvider>();
    vrsteProizvodaProvider = context.read<VrsteProizvodaProvider>();
        // TODO: implement initState
    super.initState();

    _initialValue = {
        'sifra': widget.product?.sifra,
        'naziv': widget.product?.naziv,
        'cijena': widget.product?.cijena?.toString(),
        'vrstaId': widget.product?.vrstaId?.toString(),
        'jedinicaMjereId': widget.product?.jedinicaMjereId?.toString()
    };
    
    initForm();
  }

  Future initForm() async {
     vrstaProizvodaResult = await  vrsteProizvodaProvider.get();
     jediniceMjereResult = await  jediniceMjereProvider.get();
     print("retreived jedinice mjer: ${jediniceMjereResult?.result.length}");

     print("vr ${vrstaProizvodaResult?.result}");
     setState(() {
       isLoading = false;
     });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen("Detalji"
      ,Column(children: [
          isLoading ? Container() : _buildForm(),
          _saveRow()
        ],)
     );
  }

  Widget _buildForm() {
    return FormBuilder(key: _formKey, initialValue: _initialValue,
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                children: [
                    Row(
                      children: [
                        Expanded(
                            child: FormBuilderTextField(
                              decoration: InputDecoration(labelText: "Šifra"),
                              name: "sifra",
                            )
                          ),
                          SizedBox(width: 10,),
                          Expanded(
                            child: FormBuilderTextField(
                              decoration: InputDecoration(labelText: "Naziv"),
                              name: "naziv",
                            )
                          )
                      ],
                    ),
                    Row(
                       children: [
                          Expanded(
                            child:   FormBuilderDropdown(
                              name: "vrstaId",
                              decoration: InputDecoration(labelText: "Vrsta proizvoda"),
                              items: vrstaProizvodaResult?.result.map((item) => DropdownMenuItem(value: item.vrstaId.toString() ,child: Text(item.naziv ?? ""))).toList() ?? [],
                              )
                          ),
                          SizedBox(width: 10,),
                          Expanded(
                            child:   FormBuilderDropdown(
                              name: "jedinicaMjereId",
                              decoration: InputDecoration(labelText: "Jedinica mjere"),
                              items: jediniceMjereResult?.result.map((item) => DropdownMenuItem(value: item.jedinicaMjereId.toString() ,child: Text(item.naziv ?? ""))).toList() ?? [],
                              )
                          ),
                          SizedBox(width: 10,),
                          Expanded(
                            child: FormBuilderTextField(
                              decoration: InputDecoration(labelText: "Cijena"),
                              name: "cijena",
                            )
                          )
                       ],
                    ),
                  Row(
                    children: [
                      Expanded(
                        child: FormBuilderField(
                            name: "imageId",
                            builder: (field)  {
                                return InputDecorator(
                                  decoration: InputDecoration(labelText: "Odaberite sliku"),
                                  child: ListTile(
                                      leading: Icon(Icons.image),
                                      title: Text("Select image"),
                                      trailing: Icon(Icons.file_upload),
                                      onTap: getImage,
                                  ),
                                );
                            },
                          )
                        )
                    ],
                  )
                ],),
            ));
  }
  
  Widget _saveRow() {
      return Padding(
        padding: const EdgeInsets.all(8.0),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            ElevatedButton(onPressed: () {
              _formKey.currentState?.saveAndValidate();
              debugPrint(_formKey.currentState?.value.toString());

              var request = Map.from(_formKey.currentState!.value);
              
              request['slika'] = _base64Image;


              if(widget.product == null) {
                productProvider.insert(request);
              } else {
                productProvider.update(widget.product!.proizvodId!, request);
              }

              
            }, child: Text("Sačuvaj"))
          ],
        ),
      );
  }

  File? _image;
  String? _base64Image;

  void getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null && result.files.single.path != null) {
        _image = File(result.files.single.path!);
        _base64Image = base64Encode(_image!.readAsBytesSync());
    }
  }
}



