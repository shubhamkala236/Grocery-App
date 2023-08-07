import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Order } from '../interface/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient,private authService:AuthService) { }

  private baseServerUrl = "https://localhost:44339/api/"

  //Place order
  placeOrder(cartProduct:FormData)
  {
    // const headers = this.authService.createHeader();
    return this.http.post(this.baseServerUrl+"Order/placeOrder",cartProduct,{responseType:'text'})
  }

  //get My orders
  myOrders()
  {
    // const headers = this.authService.createHeader();
    return this.http.get<Order[]>(this.baseServerUrl+"Order/myOrders");
  }

  //get Top 5 orders by month and year
  getTopOrders(month:number,year:number)
  { 
    // const headers = this.authService.createHeader();
    return this.http.get<any[]>(this.baseServerUrl+`Order/topOrders?month=${month}&year=${year}`);
  }
}
