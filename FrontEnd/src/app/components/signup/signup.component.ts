import { Component } from '@angular/core';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  SignupForm:FormGroup;

  constructor(private fb:FormBuilder,private userService:UserService,private toastr:ToastrService,private router:Router,private auth:AuthService){
    this.SignupForm = fb.group({
      name:['',[Validators.required,Validators.maxLength(50),Validators.minLength(3),Validators.pattern('^[a-zA-Z]*$')]],
      email:['',[Validators.required,Validators.email,Validators.pattern("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
      )]],
      phone:['',[Validators.required,Validators.pattern('^(0|[1-9][0-9]*)$'),Validators.minLength(10),Validators.maxLength(10)]],
      password:['',[Validators.required]],
      confirmPassword:['',[Validators.required]],
    });

    if(this.auth.isUser())
    {
      this.router.navigate(['/dashboard']);
    }
    if(this.auth.isAdmin())
    {
      this.router.navigate(['/adminDashboard']);
    }
  }

  //getters
  get name()
  {
    return this.SignupForm.get('name');
  }
  get email()
  {
    return this.SignupForm.get('email');
  }
  get phone()
  {
    return this.SignupForm.get('phone');
  }
  get password()
  {
    return this.SignupForm.get('password');
  }
  get confirmPassword()
  {
    return this.SignupForm.get('confirmPassword');
  }

  //Functions
  registerUserSubmitted(formdata:FormGroup)
  {
    console.warn("form submitted",formdata);
    if(this.SignupForm.invalid)
    {
      this.toastr.error("Invalid Form","Please Enter Form Correctly")
      return;
    }
    
    const userData:FormData = new FormData();
    userData.append('Name',formdata.value.name);
    userData.append('Email',formdata.value.email);
    userData.append('Password',formdata.value.password);
    userData.append('PhoneNumber',formdata.value.phone);

    //backend api call
    //registerUser
    this.userService.registerUser(userData).subscribe((res)=>{
      console.log(res);
      this.toastr.success("User Registered","Success");
      this.router.navigate(['/login']);
    },(error)=>{
      console.log(error);
      this.toastr.error("Failed To Register User","Email already Exist");
    });

  }
}
