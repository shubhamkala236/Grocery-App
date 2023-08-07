import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Product } from '../interface/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient,private authService:AuthService) { }

  private baseServerUrl = "https://localhost:44339/api/"

  //getMyCart items
  getMyCart()
  {
    // const headers = this.authService.createHeader();
    return this.http.get<Product[]>(this.baseServerUrl+"Cart/myCart");
  }

  //remove from cart
  removeCartItem(productId:number)
  {
    return this.http.delete(this.baseServerUrl+`Cart/deleteCartItem/${productId}`,{responseType:'text'});
  }
}
