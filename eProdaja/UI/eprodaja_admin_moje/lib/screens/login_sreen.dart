import 'package:eprodaja_admin_moje/providers/auth_provider.dart';
import 'package:eprodaja_admin_moje/providers/product_provider.dart';
import 'package:eprodaja_admin_moje/screens/porduct_screen.dart';
import 'package:flutter/material.dart';

class LoginSreen extends StatelessWidget {
  LoginSreen({super.key});

  var usernameController = TextEditingController();
  var passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Login"),
      ),
      body: Center(
        child: Container(
          padding: const EdgeInsets.only(top: 100, left: 30, right: 30),
          child: Column(
            children: [
              Image.asset("assets/images/logo.png"),
              const SizedBox(
                height: 70,
              ),
              SizedBox(
                width: 400,
                child: TextField(
                  controller: usernameController,
                  decoration: const InputDecoration(
                    hintText: "Enter your username",
                    border: OutlineInputBorder(),
                  ),
                ),
              ),
              const SizedBox(
                height: 20,
              ),
              SizedBox(
                width: 400,
                child: TextField(
                  controller: passwordController,
                  obscureText: true,
                  decoration: const InputDecoration(
                    hintText: "Enter your password",
                    border: OutlineInputBorder(),
                  ),
                ),
              ),
              const SizedBox(
                height: 5,
              ),
              SizedBox(
                width: 400,
                child: Row(
                  children: [
                    TextButton(
                      onPressed: () {},
                      child: const Text("Forgot your password?"),
                    )
                  ],
                ),
              ),
              const SizedBox(
                height: 20,
              ),
              ElevatedButton(
                onPressed: () async {
                  // print(
                  //     "${usernameController.text} ,${passwordController.text} ");
                  AuthProvider.username = usernameController.text;
                  AuthProvider.password = passwordController.text;
                  ProductProvider productProvider = ProductProvider();

                  try {
                    var data = await productProvider.get();
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) => const PorductScreen(),
                      ),
                    );
                  } catch (e) {
                    showDialog(
                      context: context,
                      builder: (context) => AlertDialog(
                        title: const Text("Error"),
                        content: Text(e.toString()),
                        actions: [
                          TextButton(
                            onPressed: () {
                              Navigator.of(context).pop();
                            },
                            child: const Text("ok"),
                          )
                        ],
                      ),
                    );
                  }
                },
                child: const Text("Login"),
              )
            ],
          ),
        ),
      ),
    );
  }
}
