import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Review } from '../interface/review';
import { FormControl } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient,private authService:AuthService) { }

  private baseServerUrl = "https://localhost:44339/api/"

  //getAll Products
  getAllProducts()
  {
    return this.http.get(this.baseServerUrl + "Product/allProducts");
  }

  //getProduct details {id}
  getProductDetails(productId:number)
  {
    // const headers = this.authService.createHeader();
    return this.http.get<any>(this.baseServerUrl+`Product/productDetails/${productId}`);
  }

  //add to card 
  addProductToCart(cartItem:FormData)
  {
    // const headers = this.authService.createHeader();
    return this.http.post(this.baseServerUrl+"Cart/addToCart",cartItem,{responseType:'text'});
  }

  //addPRoduct --admin
  addProduct(formdata:FormData)
  {
    // const headers = this.authService.createHeader();
    return this.http.post(this.baseServerUrl+"Product/addProduct",formdata,{responseType:'text'});

  }

  //updatePRoduct --admin
  updateProduct(formdata:FormData,id:number)
  {
    // const headers = this.authService.createHeader();
    return this.http.put(this.baseServerUrl+`Product/update/${id}`,formdata);
  }

  //delete product
  deleteProduct(id:number)
  {
    // const headers = this.authService.createHeader();
    return this.http.delete(this.baseServerUrl+`Product/delete/${id}`,{responseType:'text'});
  }

  //dashboard
  getProductByCategory(category:string)
  {
    return this.http.get(this.baseServerUrl+`Product/productCategory/${category}`);
  }

  //getReviews
  getProductReview(productId:number)
  {
    // const headers = this.authService.createHeader();
    return this.http.get<Review[]>(this.baseServerUrl+`Review/productReview/${productId}`);
  }

  //post review
  addReview(formData:FormData)
  { 
    // const headers = this.authService.createHeader();
    return this.http.post(this.baseServerUrl+"Review",formData,{responseType:'text'});

  }

}
