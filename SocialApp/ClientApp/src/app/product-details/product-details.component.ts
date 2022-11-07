import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../Model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {


  @Input()
            products!: Product; // dışarıdan gelen bilgiyi almak için @ınput kullanılır

  @Input()
  product!: Product[];
  constructor(private productservice : ProductService) { }

  ngOnInit(): void {
  }

  addProduct(ProductID:string,names : string,price:string,isactive:boolean){



    const p = new Product(parseInt(ProductID),names,price,isactive)


    this.productservice.updateProductService(p);

    };
  }





