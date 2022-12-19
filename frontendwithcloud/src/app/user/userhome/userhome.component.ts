import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BookOrdertbl } from 'src/app/models/bookorder.model';
import { Ordertbl } from 'src/app/models/manageorder.model';
import { Productstbl } from 'src/app/models/manageproduct.model';

@Component({
  selector: 'app-userhome',
  templateUrl: './userhome.component.html',
  styleUrls: ['./userhome.component.css']
})
export class UserhomeComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
     this.ShowData();
    
  }

  ShowData()
  {
    console.log("hi");
    this.http.get("https://shopping20221215212046.azurewebsites.net/api/Product/all")
  
    .subscribe(res => this.GetFromServer(res), res=>console.log(res));
  }  
  GetFromServer(res:any)
  {
    console.log(res);
    this.getData=res;
  }

  productstbls:Productstbl=new Productstbl();
 
  getData: Array<Productstbl>= new Array<Productstbl>();

  bookordertbls:BookOrdertbl=new BookOrdertbl();
  

  BookProduct() {
    var addData = {
      
      productid:Number(this.bookordertbls.productid),
      customerid:Number(this.bookordertbls.customerid)
    }
    console.log(addData);
    console.log(this.bookordertbls);
    this.http.post("https://shopping20221215212046.azurewebsites.net/api/Order/add", addData)
    .subscribe(res => { console.log(res) }, res => console.log(res));
    this.bookordertbls= new BookOrdertbl();
  
  }  


}
