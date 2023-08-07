import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/interface/product';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  constructor(private toastr:ToastrService,private productService:ProductService,private router:Router){ }
  
  ngOnInit(): void {
    this.getAllProducts();
    this.selectedCategory='All'
  }

  allProducts:Product[]=[];
  filteredProducts:Product[]=[];
  page:any;
  searchTerm:string='';
  selectedCategory:string='';

  //getAll products
  getAllProducts()
  {
    this.productService.getAllProducts().subscribe((res:any)=>{
      console.log(res);
      this.allProducts = res;
      this.filteredProducts=this.allProducts;
    },(error)=>{
      console.log(error);
    })
  }

  //edit
  editProduct(productId:number)
  {
    this.router.navigate([`/updateProduct/${productId}`]);
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
  
  

  //delete
  deleteProduct(productId:number)
  {
    Swal.fire({
      title:'Are you sure?',
      text:'You will not be able to recover deleted product!',
      icon:'warning',
      showCancelButton:true,
      confirmButtonText:'Yes, delete it!',
      cancelButtonText:'No, keep it'
    }).then((result)=>{
      if(result.value)
      {
        //apicall
        this.productService.deleteProduct(productId).subscribe((res)=>{
          console.log(res);
          this.getAllProducts();
          this.toastr.success("Deleted Success !!","Product Deleted")    
          Swal.fire(
            'Deleted',
            'Your record has been deleted',
            'success'
          )
        },(error)=>{
          console.log(error);
          this.toastr.error("Unable to delete record !!","Failed Delete")    
        });
      }
      else if(result.dismiss === Swal.DismissReason.cancel)
      {
        Swal.fire('Cancelled','Your record is safe :)','error')
      }
    })
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

}
