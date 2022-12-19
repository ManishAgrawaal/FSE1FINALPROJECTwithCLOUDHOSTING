import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Adminstbl } from 'src/app/models/adminlogin.model';
import { Userstbl } from 'src/app/models/Userreg.model';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  //styleUrls: ['./adminlogin.component.css']
})
export class AdminloginComponent implements OnInit {


  constructor(private http:HttpClient,private _router:Router) { }
  admintbls:Adminstbl=new Adminstbl();
  ngOnInit(): void {

  }
  Login()
  {
  var loginvar={
    userName:this.admintbls.UserName,
    password:this.admintbls.Password

  }
    
    if(loginvar.userName=='admin' && loginvar.password=='admin@321')
    {
      this._router.navigate(['/admin/dashboard'])
    }
    else
    {
      alert("Failed ! please enter username and password");
    }
  }


}
