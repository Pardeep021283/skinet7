import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './Models/Product';
import { Pagination } from './Models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'Skient';
  prodcuts: Product[]=[];
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products?pagesize=50').subscribe({
      next: (response)=>this.prodcuts = response.data,
      error: error=>console.log(error),
      complete: ()=>{
        console.log('request completed');
        console.log('extra statment');
      }
    })
  }
}
