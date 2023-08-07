import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-top-orders',
  templateUrl: './top-orders.component.html',
  styleUrls: ['./top-orders.component.css']
})
export class TopOrdersComponent implements OnInit {
  constructor(private toastr:ToastrService,private orderService:OrderService,private router:Router){}
  
  selectedMonth:any;
  selectedYear:any;
  topProducts:any;

  ngOnInit(): void {
    const currentDate = new Date();
    this.selectedMonth = currentDate.getMonth()+1;
    this.selectedYear = currentDate.getFullYear();
    this.getTopOrders();
  }

  getTopOrders()
  {
    this.orderService.getTopOrders(this.selectedMonth,this.selectedYear).subscribe((res:any)=>{
      this.topProducts = res;
      console.log(this.topProducts);
      
    },(error)=>{
      console.log(error);
      this.toastr.error("Error while fetching orders","Admin Only")
    })
  }
    

  sumbitForm()
  {
    this.getTopOrders();
  }

}
