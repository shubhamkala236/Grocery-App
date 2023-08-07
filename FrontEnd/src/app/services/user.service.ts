import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  private baseServerUrl = "https://localhost:44339/api/"
  
  //register User
  registerUser(user:FormData)
  {
    return this.http.post(this.baseServerUrl + "User/register",user,{
      responseType:'text'
    });
  }

  //Login User
  loginUser(credentials:FormData)
  {
    return this.http.post(this.baseServerUrl + "User/login",credentials);
  }
}
