import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Ordertbl } from 'src/app/models/manageorder.model';

@Component({
  selector: 'app-manageorder',
  templateUrl: './manageorder.component.html',
  styleUrls: ['./manageorder.component.css']
})
export class ManageorderComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
     this.ShowData();
    
  }

  ShowData()
  {
    console.log("hi");
    //this.http.get("https://localhost:44346/api/OrderHistory/ViewDetails")
    this.http.get("https://shopping20221215212046.azurewebsites.net/api/MainOrder/all")
  
    .subscribe(res => this.GetFromServer(res), res=>console.log(res));
  }  
  GetFromServer(res:any)
  {
    console.log(res);
    this.getData=res;
  }

  ordertbls:Ordertbl=new Ordertbl();
 
  getData: Array<Ordertbl>= new Array<Ordertbl>();

  
  

}
