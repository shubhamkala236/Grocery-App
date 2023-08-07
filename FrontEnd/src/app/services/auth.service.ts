import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private router:Router) { }

  currentUser:BehaviorSubject<any> = new BehaviorSubject(null);

  jwtHelpherService = new JwtHelperService();

  setToken(token:string)
  {
    localStorage.setItem("token",token);
    this.loadCurrentUser();
  }

  getToken():string|null
  {
    return localStorage.getItem("token");
  }

  createHeader()
  {
    const token = this.getToken();
    if(token!=null)
    {
      const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`);
      return headers;
    }
    return;
  }

  loadCurrentUser()
  {
    const token = localStorage.getItem("token");
    const userInfo = token!=null? this.jwtHelpherService.decodeToken(token) : null;
    // console.log(userInfo);
    // console.log(userInfo.unique_name[0],userInfo.role);
    return userInfo;
  }

  getRole():string|null
  {
    if(this.loadCurrentUser()==null)
    {
      return null;
    }
    return this.loadCurrentUser().role;
  }

  getUserId():string
  {
    console.log(this.loadCurrentUser().nameid);
    if(this.loadCurrentUser()==null)
    {
      return '';
    }
    return this.loadCurrentUser().nameid;
     
  }

  getName():any
  {
    if(this.loadCurrentUser()==null)
    {
      return null;
    }
    return this.loadCurrentUser().unique_name[0];
  }
    
  isAdmin()
  {
    if(this.getRole()=='admin')
    {
      return true;
    }
    return false;
  }

  isUser()
  {
    if(this.getRole()=='user')
    {
      return true;
    }
    return false;
  }

  isLoggedIn()
  {
    return this.getRole()!=null;
  }

  logOut()
  {
    localStorage.clear();
    localStorage.removeItem("token");
    this.router.navigate(['/']);
  }

}
