import 'package:flutter/material.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  String _email = "";
  String _password = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Login"),
      ),
      body: Center(
        child: Card(
          child: SingleChildScrollView(
            // Allow content to scroll if keyboard appears
            padding: EdgeInsets.all(30.0),
            child: Column(
              children: [
                // Company logo (replace with your logo image asset)
                Image.network(
                  "https://www.fit.ba/content/763cbb87-718d-4eca-a991-343858daf424",
                  height: 100,
                  width: 100,
                ), // Replace with your asset path
                SizedBox(height: 20.0),

                // Email field
                TextField(
                  decoration: InputDecoration(
                    labelText: 'Email',
                    border: OutlineInputBorder(),
                  ),
                  keyboardType: TextInputType.emailAddress,
                  onChanged: (value) => setState(() => _email = value),
                ),
                SizedBox(height: 10.0),

                // Password field
                TextField(
                  decoration: InputDecoration(
                    labelText: 'Password',
                    border: OutlineInputBorder(),
                    // Hide password characters
                  ),
                  obscureText: true,
                  onChanged: (value) => setState(() => _password = value),
                ),
                SizedBox(height: 20.0),

                // Login button
                ElevatedButton(
                  onPressed: () {
                    // Handle login logic (e.g., validate email/password, call API)
                    print(
                        'Logging in with email: $_email, password: $_password');
                  },
                  child: Text('Login'),
                ),
                SizedBox(height: 20.0),

                // Register link
                TextButton(
                  onPressed: () {
                    // Navigate to register page (implementation not shown here)
                    print('Navigating to register page');
                  },
                  child: Text("Don't have an account, register here"),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
