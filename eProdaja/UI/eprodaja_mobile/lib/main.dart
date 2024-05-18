import 'package:eprodaja_mobile/pages/home_page.dart';
import 'package:eprodaja_mobile/pages/login_page.dart';
import 'package:eprodaja_mobile/pages/register_page.dart';
import 'package:eprodaja_mobile/pages/reset_password_page.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      // home: LoginPage(),
      home: const LoginPage(),
      routes: {
        "/register": (context) => const RegisterPage(),
        "/login": (context) => const LoginPage(),
        "/resetpassword": (context) => const ResetPasswordPage(),
        "/home": (context) => const HomePage(),
      },
    );
  }
}
