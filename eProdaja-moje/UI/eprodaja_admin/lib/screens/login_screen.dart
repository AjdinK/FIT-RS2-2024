import 'package:eprodaja_admin/screens/forgot_password_screen.dart';
import 'package:eprodaja_admin/screens/product_list_screen.dart';
import 'package:flutter/material.dart';

import '../providers/auth_provider.dart';
import '../providers/product_provider.dart';

class LoginScreen extends StatelessWidget {
  LoginScreen({super.key});

  var _usernameController = new TextEditingController();
  var _passwordController = new TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(100),
          child: SingleChildScrollView(
            child: Container(
              constraints: const BoxConstraints(
                maxHeight: 500,
                maxWidth: 500,
              ),
              child: Column(
                children: [
                  const Text(
                    "LOGO",
                    style: TextStyle(
                      fontSize: 40,
                      color: Colors.black87,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic,
                    ),
                  ),
                  const SizedBox(
                    height: 50,
                  ),
                  const SizedBox(
                    height: 30,
                  ),
                  TextField(
                    controller: _usernameController,
                    decoration: InputDecoration(
                      prefixIcon: const Icon(Icons.perm_identity_sharp),
                      labelText: "Username",
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(9),
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextField(
                    controller: _passwordController,
                    obscureText: true,
                    decoration: InputDecoration(
                      prefixIcon: const Icon(Icons.password_rounded),
                      labelText: "Password",
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(9),
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Row(
                    children: [
                      TextButton(
                        onPressed: () {
                          Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) =>
                                  const ForgotPasswordScreen(),
                            ),
                          );
                        },
                        child: const Text("Forgot Password?"),
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 30,
                  ),
                  ElevatedButton(
                    onPressed: () async {
                      AuthProvider.username = _usernameController.text;
                      AuthProvider.password = _passwordController.text;
                      ProductProvider productProvider = ProductProvider();
                      try {
                        var data = await productProvider.get();
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const ProductListScreen(),
                          ),
                        );
                      } catch (e) {
                        showDialog(
                          context: (context),
                          builder: (context) => AlertDialog(
                            title: const Text("Error"),
                            content: Text(
                              e.toString(),
                            ),
                            actions: [
                              TextButton(
                                onPressed: () {
                                  Navigator.pop(context);
                                },
                                child: const Text("Ok"),
                              )
                            ],
                          ),
                        );
                      }
                    },
                    child: const Text("Log in"),
                  ),
                  const SizedBox(
                    height: 40,
                  ),
                  TextButton(
                    onPressed: () {},
                    child: const Text(
                        "Dont have an account? , register here now!"),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
