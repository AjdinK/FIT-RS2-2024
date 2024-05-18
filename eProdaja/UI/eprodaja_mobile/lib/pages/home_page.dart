import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  String _email = "";

  String _password = "";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue[200],
        title: const Text("login"),
      ),
      backgroundColor: Colors.blue[100],
      body: Center(
        child: Card(
          margin: EdgeInsets.all(20),
          color: Colors.white,
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
