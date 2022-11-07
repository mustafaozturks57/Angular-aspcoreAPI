import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Model, Product } from './Model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  BaseUrl: string = "https://localhost:7294/";
  model = new Model();

  constructor(private http: HttpClient) { }





  getProducts() : Observable<Product[]> {
// akış ne zaman biter diye bekler subscrıbe/Observable burada bekler hepsi gelince method döner
    //return this.model.products;
   // this.http.get<Product>(this.BaseUrl + 'products').subscribe(); // akış ne zaman biter diye bekler subscrıbe
    return   this.http.get<Product[]>(this.BaseUrl + 'Products');

  }


  getProductById(id: Number){
   return this.model.products.find(x=>x.productID ==id);

  }

addProductService(product:Product) : Observable<Product> {
return this.http.post<Product>(this.BaseUrl + 'Products',product);

}


updateProductService(product:Product)
{
 this.http.put<Product>(this.BaseUrl+ 'Products'+product.productID,product);
 console.log("güncellendi");

}
  saveProduct(product : Product){

    if(product.productID==0)
    {

   this.model.products.push(product); // array listeye eleman ekliyoruz
  }
  else
  {
    const p = this.getProductById(product.productID);
    if(p!=null)
    {
      console.log(p.productID + "  Numaralı kayıt güncellenmiştir");
      p.names=product.names;
      p.price=product.price;
      p.isActive=product.isActive;
    }


  }
  }

  removeProduct(id : number){
    const p =   this.model.products.find(x=>x.productID ==id);

  }
}
