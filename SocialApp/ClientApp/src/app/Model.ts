export class Model {

  categoryName:string;
  products:Array<Product>; // deger belirtme
  /**
   *
   */
  constructor() {
    this.categoryName = "telefon";


    this.products= [ // modelin içince class tan list oluşturup veri eklendi ,

      new Product(1,"samsung s11","2700",true),
      new Product(2,"samsung s12","2800",true),
      new Product(3,"samsung s13","2900",true),
      new Product(4,"samsung s14","21200",true),
      new Product(5,"samsung s14","21200",true),
      new Product(6,"samsung s14","21200",true)
    ];


  }


}
export class Product {
  push(product: Product) {
    throw new Error('Method not implemented.');
  } //burada model olusturuldu product class olustuurldu
  productID :Number;
  names:string;
price:string;
isActive:boolean;

/**
 *
 */
constructor(productID:number,names:string,price:string,isActive:boolean) { // class a constractor verildi yukarıda tanımlananlar ile birleştirildi .this
   this.productID=productID;
   this.names=names;
   this.price=price;
   this.isActive=isActive;
}

}
