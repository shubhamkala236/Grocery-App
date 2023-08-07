import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Order } from 'src/app/interface/order';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  
  constructor(private toastr:ToastrService,private orderService:OrderService,private router:Router){}
  
  myOrders:Order[]=[];
  isOrdersEmpty:boolean = false;

  ngOnInit(): void {
    this.getOrders();
  }

  //get my orders
  getOrders()
  {
    this.orderService.myOrders().subscribe((res:Order[])=>{
      this.myOrders = res;
      console.log(this.myOrders);
      if(this.myOrders.length > 0)
      {
        this.isOrdersEmpty = false;
      }
      else
      {
        this.toastr.warning("Please Order Some Items","No Orders");
        this.isOrdersEmpty = true;
      }
      
    },(error)=>{
      console.log(error);
      this.toastr.error("Error while fetching orders","Users Only")
    })
  }

}
