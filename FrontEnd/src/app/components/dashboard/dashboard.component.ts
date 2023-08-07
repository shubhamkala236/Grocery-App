import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/interface/product';
import { AuthService } from 'src/app/services/auth.service';

import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  
  constructor(private toastr:ToastrService,private productService:ProductService,private router:Router,private authService:AuthService){ }
  
  allProducts:Product[]=[];
  filteredProducts:Product[]=this.allProducts;
  page:any;
  searchTerm:string='';
  fullName:string|null='';
  // showDetailsColumn:boolean=false;
  selectedCategory:string='';
  
  ngOnInit(): void {
  this.productService.getAllProducts().subscribe((res:any)=>{
      console.log(res);
      this.allProducts = res;
      this.filteredProducts=this.allProducts;
      // this.toastr.success("Welcome to Dashboard");
    },(error)=>{
      console.log(error);
      this.toastr.error("Failed To Fetch Products","Database");
    });
    
    this.fullName = this.authService.getName();
    // this.showDetailsColumn = this.authService.isUser();
    this.selectedCategory='All';
  }

  //view Product details
  viewProduct(productId:number)
  {
    this.router.navigate([`/productDetails/${productId}`]);
  }

  //view products by category
  viewProductsByCategory()
  {
    this.productService.getProductByCategory(this.selectedCategory).subscribe((res:any)=>{
      console.log(res);
      this.allProducts = res;
      this.filteredProducts=this.allProducts;
    },(error)=>{
      console.log(error);
      this.toastr.error("Failed To Fetch Products by Category","Database");
    });
  }

  onCategoryChange(category:string)
  {
    if(category=='All')
    {
      this.productService.getAllProducts().subscribe((res:any)=>{
        console.log(res);
        this.allProducts = res;
        this.filteredProducts=this.allProducts;
        // this.toastr.success("Welcome to Dashboard");
      },(error)=>{
        console.log(error);
        this.toastr.error("Failed To Fetch Products","Database");
      });
      return;
    }
    this.selectedCategory = category;
    this.viewProductsByCategory();
  }
  //search
  search() {
    this.page=1;
    this.filteredProducts = this.allProducts.filter(product =>
      product.productName.toLowerCase().includes(this.searchTerm.toLowerCase()) || product.description.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

currentSortColumn: string = '';
currentSortDirection: string = '';

  //sort
  sort(column: string) {
    if (this.currentSortColumn === column) {
      this.currentSortDirection = this.currentSortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.currentSortColumn = column;
      this.currentSortDirection = 'asc';
    }
  
    this.filteredProducts.sort((a, b) => {
      let valA, valB;
  
      if (column === 'price') {
        valA = a.price
        valB = b.price;
      } else {
        // Convert other values to lowercase strings before comparing
        valA = a.productName.toLowerCase();
        valB = b.productName.toLowerCase();
      }
  
      if (valA < valB) {
        return this.currentSortDirection === 'asc' ? -1 : 1;
      } else if (valA > valB) {
        return this.currentSortDirection === 'asc' ? 1 : -1;
      } else {
        return 0;
      }
    });
  };
  

}
