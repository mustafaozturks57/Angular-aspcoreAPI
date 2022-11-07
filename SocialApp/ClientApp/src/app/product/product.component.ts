import { Component, OnInit } from '@angular/core';
import { Model, Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products : Product[] | undefined;
  selectedProduct!: Product;

  constructor(private ProductService : ProductService) { }



  ngOnInit(): void {
//burası formload gibi düşün
this.getProducts();

  }

getProducts()  {
      this.ProductService.getProducts().subscribe(products=>
  {

  this.products =  products

 });


}



onselectedProduct(product:Product){ // seçilenleri aktarmak için yapılır
  console.log("devam");
this.selectedProduct = product;

}


}
