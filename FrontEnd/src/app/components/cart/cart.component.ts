import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartProduct } from 'src/app/interface/cart-product';
import { Product } from 'src/app/interface/product';
import { CartService } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit{
  constructor(private toastr:ToastrService,private cartService:CartService,private orderService:OrderService,private router:Router){}

  cartProducts:CartProduct[]=[];
  selectedProduct:CartProduct=
  {
    imageUrl:'',
    discount:0,
    price: 0,
    productId: 0,
    productName:'',
    quantity: 0
  };
  isCartEmpty:boolean = false;

  ngOnInit(): void {
    this.getMyCart();
  }

  //get my cart
  getMyCart()
  {
    this.cartService.getMyCart().subscribe((res:Product[])=>{
      console.log(res);
      this.cartProducts = res.map((p:Product)=>{
        return {
          imageUrl: p.imageUrl,
          discount:p.discount,
          price: p.price,
          productId: p.productId,
          productName: p.productName,
          quantity: p.quantity
        };
      });
      console.log(this.cartProducts);
      if(this.cartProducts.length > 0)
      {
        this.isCartEmpty = false;
      }
      else{
        this.toastr.warning("Please Add Items To Cart","Cart Empty");
        this.isCartEmpty = true;
      }
    },(error)=>{
      console.log(error);
    });
  }

  //remove from cart
  removeFromCart(productId:number)
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
        this.cartService.removeCartItem(productId).subscribe((res)=>{
          console.log(res);
          this.getMyCart();
          this.toastr.success("Deleted Success !!","Product Removed from cart")    
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
        Swal.fire('Cancelled','Your Cart is safe :)','error')
      }
    })
  }

  //select product to order and set in variable
  selectedCartProduct(product:CartProduct)
  {
    // console.log(product);
    this.selectedProduct = product;
    console.log(this.selectedProduct);
  }

  placeOrderSelectedProduct()
  {
    if(this.selectedProduct.productName!='')
    {
      console.log(this.selectedProduct);
      const cartSelectedItem:FormData = new FormData();
      cartSelectedItem.append('ProductId',String(this.selectedProduct.productId));
      cartSelectedItem.append('OrderQuantityDto',String(this.selectedProduct.quantity));
      cartSelectedItem.append('OrderImageUrl',this.selectedProduct.imageUrl);
      cartSelectedItem.append('OrderName',this.selectedProduct.productName);
      //call api
      this.orderService.placeOrder(cartSelectedItem).subscribe((res)=>{
        console.log(res);
        this.toastr.success("Order Successfull","Order Placed")
        this.router.navigate(['/myOrders']);
      },(error)=>{
        console.log(error);
        if(error.status===400)
        {
          this.toastr.error("Quantity Not Available","Order Failed")
        }
        else{
          this.toastr.error("Order Failed")
        }
      })
    }
    else{
      this.toastr.warning("Please Select Item","Place Order");
      return;
    }
  }

  increment(product:CartProduct) {
    product.quantity ++;
  }

  decrement(product:CartProduct) {
    if(product.quantity > 1)
    {
      product.quantity --;
    }
  }
}

