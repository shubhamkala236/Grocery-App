import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { CartComponent } from './components/cart/cart.component';
import { OrdersComponent } from './components/orders/orders.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { AuthUserGuard } from './guards/auth-user.guard';
import { AuthAdminGuard } from './guards/auth-admin.guard';
import { TopOrdersComponent } from './components/top-orders/top-orders.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'signup',
    component: SignupComponent,
  },
  {
    //user 
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    //anonymous users
    path: 'productDetails/:id',
    // canActivate:[AuthUserGuard],
    component: ProductDetailsComponent,
  },
  {
    //user
    path: 'myCart',
    canActivate:[AuthUserGuard],
    component: CartComponent,
  },
  {
    //user
    path: 'myOrders',
    canActivate:[AuthUserGuard],
    component: OrdersComponent,
  },
  {
    //admin
    path: 'addProduct',
    canActivate:[AuthAdminGuard],
    component: AddProductComponent,
  },
  {
    //admin
    path: 'updateProduct/:id',
    canActivate:[AuthAdminGuard],
    component: UpdateProductComponent,
  },
  {
    //admin
    path: 'adminDashboard',
    canActivate:[AuthAdminGuard],
    component: AdminDashboardComponent,
  },
  {
    //admin
    path: 'topOrders',
    canActivate:[AuthAdminGuard],
    component: TopOrdersComponent,
  },
  {
    //admin
    path: '**',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
