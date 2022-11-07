import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  @Input()
  products?: Product[];
  constructor(private ProductService : ProductService) { }

  ngOnInit(): void {
  }

addProduct(name : string,price:string,isactive:boolean){

const p = new Product(0,name,price,isactive)

this.ProductService.addProductService(p)
.subscribe(product => {
  this.products?.push(product);
}

);


}
}
