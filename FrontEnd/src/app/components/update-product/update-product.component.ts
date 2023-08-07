import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/interface/product';
import { UpdateProduct } from 'src/app/interface/update-product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent {
  updateProductForm:FormGroup;
  productId: number;
  productDetails:UpdateProduct|null=null;

  
  constructor(private fb:FormBuilder,private productService:ProductService,private toastr:ToastrService,private router:Router,private activatedRoute:ActivatedRoute)
  {
    this.updateProductForm = this.fb.group({
      ProductName:['',[Validators.required,Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Description:['',[Validators.required,Validators.maxLength(255),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Category:['',[Validators.required,Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
      Quantity:['',[Validators.required,Validators.pattern("^[0-9]*$")]],
      ImageFile:[null, [Validators.required,Validators.pattern(/\.(jpg|jpeg|png)$/i)]],
      Price:['',[Validators.required,Validators.pattern("^[0-9]*$")]],
      Discount:['',[Validators.pattern("^[0-9]*$")]],
      Specification:['',[Validators.maxLength(100),Validators.minLength(3),Validators.pattern('^[a-zA-Z0-9]*$')]],
    });

    this.productId = this.activatedRoute.snapshot.params['id'];

    //fetch data based on id
    this.getProductDetails();
  }


  
  //getters
  get ProductName()
  {
    return this.updateProductForm.get('ProductName');
  }
  get Description()
  {
    return this.updateProductForm.get('Description');
  }
  get Category()
  {
    return this.updateProductForm.get('Category');
  }
  get Quantity()
  {
    return this.updateProductForm.get('Quantity');
  }
  get ImageFile()
  {
    return this.updateProductForm.get('ImageFile');
  }
  get Price()
  {
    return this.updateProductForm.get('Price');
  }
  get Discount()
  {
    return this.updateProductForm.get('Discount');
  }
  get Specification()
  {
    return this.updateProductForm.get('Specification');
  }

  imageFile:any;
  //Imagefile
  onFileChange(event:any)
  {
    this.imageFile = event.target.files[0];
  }
  
  getProductDetails()
  {
    //call api to get product details
    this.productService.getProductDetails(this.productId).subscribe((res:Product)=>{
      console.log(res);

      this.productDetails = {
        category: res.category,
        description:res.description,
        imageUrl:'',
        discount:res.discount,
        price: res.price,
        productName: res.productName,
        quantity: res.quantity,
        specification: res.specification,

      };
      //fill form data
      this.updateProductForm.patchValue({
        ProductName:this.productDetails.productName,
        Category:this.productDetails.category,
        Description:this.productDetails.description,
        ImageFile:this.productDetails.imageUrl,
        Discount:this.productDetails.discount,
        Price:this.productDetails.price,
        Quantity:this.productDetails.quantity,
        Specification:this.productDetails.specification,
      })
    },(error)=>{
      console.log(error);
    });
  }

  //submit form
  submitForm(formData:FormGroup)
  {
    console.log(formData.value);
    if(this.updateProductForm.invalid)
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
    this.productService.updateProduct(productData,this.productId).subscribe((res)=>{
      console.log(res);
      this.toastr.success("Product Updated","Success");
      this.router.navigate(['/adminDashboard']);
    },(error)=>{
      console.log(error);
      this.toastr.error("Unable To Update Product","Failure")
    })
  }

}
