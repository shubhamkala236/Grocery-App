import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent  {
  addProductForm:FormGroup;
  
  constructor(private fb:FormBuilder,private productService:ProductService,private toastr:ToastrService,private router:Router)
  {
    this.addProductForm = this.fb.group({
      ProductName:['',[Validators.required,Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Description:['',[Validators.required,Validators.maxLength(255),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Category:['',[Validators.required,Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Quantity:['',[Validators.required,Validators.pattern("^[0-9]*$")]],
      ImageFile:[null, [Validators.required,Validators.pattern(/\.(jpg|jpeg|png)$/i)]],
      Price:['',[Validators.required,Validators.pattern("^[0-9]*$")]],
      Discount:['',[Validators.pattern("^[0-9]*$")]],
      Specification:['',[Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
    });
  }


  
  //getters
  get ProductName()
  {
    return this.addProductForm.get('ProductName');
  }
  get Description()
  {
    return this.addProductForm.get('Description');
  }
  get Category()
  {
    return this.addProductForm.get('Category');
  }
  get Quantity()
  {
    return this.addProductForm.get('Quantity');
  }
  get ImageFile()
  {
    return this.addProductForm.get('ImageFile');
  }
  get Price()
  {
    return this.addProductForm.get('Price');
  }
  get Discount()
  {
    return this.addProductForm.get('Discount');
  }
  get Specification()
  {
    return this.addProductForm.get('Specification');
  }

  imageFile:any;
  //Imagefile
  onFileChange(event:any)
  {
    this.imageFile = event.target.files[0];
  }
  
  //submit form
  submitForm(formData:FormGroup)
  {
    console.log(formData.value);
    if(this.addProductForm.invalid)
    {
      this.toastr.error("Invalid Form","Please Enter Form Correctly")
      return;
    }
 
    //send formData value to api
    const productData:FormData = new FormData();
    productData.append('ProductName',formData.value.ProductName);
    productData.append('Description',formData.value.Description);
    productData.append('Category',formData.value.Category);
    productData.append('Quantity',formData.value.Quantity);
    productData.append('ImageFile',this.imageFile);
    productData.append('Price',(formData.value.Price));
    productData.append('Discount',formData.value.Discount);
    productData.append('Specification',formData.value.Specification);

    
    //send form to backend api
    this.productService.addProduct(productData).subscribe((res)=>{
      console.log(res);
      this.toastr.success("Product Added","Success");
      this.router.navigate(['adminDashboard']);
    },(error)=>{
      console.log(error);
      if(error.status===409)
      {
        this.toastr.error("Already Exists","Failure")
      }
      else{
        this.toastr.error("Unable To Add Product","Failure")
      }
    })
    
  }

}
