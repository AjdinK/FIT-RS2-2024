import 'package:collection/collection.dart';
import 'package:eprodaja_mobile/models/cart.dart';
import 'package:eprodaja_mobile/models/proizvod.dart';
import 'package:flutter/widgets.dart';



class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Proizvod product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Proizvod product) {
    cart.items.removeWhere((item) => item.product.proizvodId == product.proizvodId);
    notifyListeners();
  }

  CartItem? findInCart(Proizvod product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.proizvodId == product.proizvodId);
    return item;
  }
}