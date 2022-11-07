import { Component } from '@angular/core';
import { Model } from './Model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'selamlar';
  CategoryName = 'Telefon'; // burada tanımlanan bilgiler html içersiine eklenebilir

productstest = [

  {id:1,name:"samsung s5",price:2000,isActive:false},
  {id:2,name:"samsung s6",price:3000,isActive:true},
  {id:3,name:"samsung s7",price:4000,isActive:false},
  {id:4,name:"samsung s8",price:5000,isActive:true},
  {id:5,name:"samsung s9",price:6000,isActive:true}
];
  model  = new Model(); // class cagırıldı ve method tanımlandı onun içlerine classtan dönen değerler alındı
  getName(){
return this.model.categoryName;

  }
  getProducts(){
    return this.model.products;

      }
}


