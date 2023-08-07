import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(private authService:AuthService){}

  userName:string|null='';
  //isAdmin
  adminLogin()
  {
    return this.authService.isAdmin();
  }

  //isUSer
  userLogin()
  {
    return this.authService.isUser();
  }

  isLoggedIn()
  {
    //set name 
    this.userName = this.authService.getName();
    return this.authService.isLoggedIn();
  }

  //logout
  logOut()
  {
    this.authService.logOut();
  }

  
}
