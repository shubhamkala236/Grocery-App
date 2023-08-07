import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Review } from 'src/app/interface/review';
import { ProductService } from 'src/app/services/product.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  constructor(private fb:FormBuilder,private productService:ProductService,private activatedRoute:ActivatedRoute,private toastr:ToastrService,private router:Router,private authService:AuthService){}

  count:number=1;
  quantity:number = 0;
  productId:any;
  product:any;
  productName:string='';
  productPrice:number=0;
  productDiscount:number=0;
  imageUrl:string='';
  allReviews:Review[]=[];
  userName:string|null='';
  isOutOfStock:boolean = false;


  reviewForm:any;

  ngOnInit(): void {
    this.productId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getProductDetails(this.productId);
    this.setForm();
    this.getProductReviews(this.productId);
    this.userLogin();
  }

  //isLoggedIn
  //isUSer
  userLogin()
  {
    return this.authService.isUser();
  }
  
  //set form
  setForm()
  {
    this.reviewForm = this.fb.group({
      rating:[1,[Validators.required]],
      comment:['',[Validators.required]],
    });
  }

    //getters
    get comment()
    {
      return this.reviewForm.get('comment');
    }
    get rating()
    {
      return this.reviewForm.get('rating');
    }

  //get product details
  getProductDetails(productId:number)
  {
    this.productService.getProductDetails(productId).subscribe((res)=>{
      console.log(res);
      this.product = res;
      this.productName = this.product.productName;
      this.productPrice = this.product.price;
      this.productDiscount = this.product.discount;
      this.quantity = this.product.quantity;
      this.imageUrl = this.product.imageUrl;

      if(this.product.quantity == 0)
      {
        this.isOutOfStock = true;
      }
      else{
        this.isOutOfStock = false;
      }

    },(error)=>{
      console.log(error);
      this.toastr.error("Failed To Fetch ProductDetails","Error");
    })
  }

  //submit review
  submitReview(formData:FormGroup)
  {
    // debugger
    console.log(this.authService.getUserId(),this.productId,this.authService.getName(),formData.value);
    const reviewFormData:FormData = new FormData();
    reviewFormData.append('UserId',this.authService.getUserId());
    reviewFormData.append('ProductId',this.productId);
    reviewFormData.append('UserName',this.authService.getName());
    reviewFormData.append('Rating',formData.value.rating);
    reviewFormData.append('Comment',formData.value.comment);

    reviewFormData.get('Rating');

    //send to api
    this.productService.addReview(reviewFormData).subscribe((res)=>{
      console.log(res);
      this.toastr.success("Review Added","Success");
      this.router.navigate(['dashboard']);
    },(error)=>{
      console.log(error);
        this.toastr.error("Unable To Add Review","Failure Please Select Rating Also")
    })
  }

  //get reviews
  getProductReviews(productId:number)
  {
    this.productService.getProductReview(productId).subscribe((res:Review[])=>{
      console.log(res);
      this.allReviews = res.map(review=>({
        comment:review.comment,
        rating:review.rating,
        reviewDate:review.reviewDate,
        userName:review.userName
      }))
      console.log(this.allReviews);
    },(error)=>{
      console.log(error);
    })
  }

  increment() {
    this.count++;
  }

  decrement() {
    if (this.count > 0) {
      this.count--;
    }
  }

  //Add to cart
  addToCart()
  {
    // console.log(this.count,Number(this.productId));
    const cartItem:FormData = new FormData();
    cartItem.append('ProductId',this.productId);
    cartItem.append('QuantityAdded',String(this.count));
    // console.log(String(this.count),this.productId);
    
    //backend api call via service
    this.productService.addProductToCart(cartItem).subscribe((res)=>{
      console.log(res);
      this.router.navigate(['/myCart']);
      this.toastr.success("Item Added","Added To Cart")
    },(error)=>{
      console.log(error);
    })
  }

  
}
