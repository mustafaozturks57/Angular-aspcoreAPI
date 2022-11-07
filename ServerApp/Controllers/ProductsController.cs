using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.DTO;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("[controller]")] // api ıskeleti bu şekilde olucxak diye belirtildi localhost:5000/controller
    public class ProductsController : ControllerBase
    {
        


#region SadeceSayfaErisimiolanlar

 private readonly List<Product> _products;


 private readonly  SocialContext _socialContext;
//context i buraya çağırıp sonrasında controllerdan newleyip ef core crud işlemi yapmamızı sagladı

#endregion
        #region ConstroctorYapısı
public ProductsController(SocialContext social)
{

    _socialContext=social;

    // bir list product oluşturma ve içine veri ekleme işlemi
    _products = new List<Product>();
    _products.Add(new Product(){ProductID=1,Names="Buzdolabı",Price=11123,IsActive=true });
    _products.Add(new Product(){ProductID=2,Names="Çamaşır",Price=7232,IsActive=true });
    _products.Add(new Product(){ProductID=3,Names="Tost Makinesi",Price=5231,IsActive=true });
    _products.Add(new Product(){ProductID=4,Names="Dolap",Price=1223,IsActive=false });
    _products.Add(new Product(){ProductID=5,Names="böcek Cihazı",Price=2300,IsActive=false });
}
        #endregion





#region AllGet

 

[HttpGet]
     public async Task<ActionResult>  Get()
      {
        var products = await _socialContext.
        
        
        products
        //select yapısı dto da ara katman bir class giri g
        //görünür yani api de tabloya ait göstermek istemediğimiz alanları dto daki
        // tablonun içerisine yazmayız 
        //o alanlar api de görünmez olur 

        //asenkton kullanım mevcuttur şöyle düşün burger da sipariş sırasındansın tek kassayı beklemiyorsun 
        //diğer kasalar boşalınca onlara gidiyorsun 
        // api den cok kişi istek atabilir bizlerde asenkron kullanıp boşalan istek yerlerini hizmete sunalım .,


        .Select(p=> new ProductDTO(){

            ProductID= p.ProductID,
            Names= p.Names,
            Price= p.Price,
            isActive = p.IsActive
            
            

         }).
        
         ToListAsync(); 
         return  Ok(products);


      }

      #endregion
#region Getid

     [HttpGet("{id}")]
     public async Task<ActionResult>  Get(int id) // asenkron tanımlama için Task<> diye tanımlarız ve başına async koyarız
      {
         var p = await _socialContext. // methodları sıra ile yapması için await komutu gömeriz.
         
         products
         .Select(p=> new ProductDTO(){ // SELECT İLE DTO KULLANIRIZ 

            ProductID= p.ProductID,
            Names= p.Names,
            Price= p.Price
            
            

         }).
         Where(x=>x.ProductID==id).FirstOrDefaultAsync();
           if(p==null)
           {
            return NotFound();
           }
else{

     return Ok(p);
}


      }
          #endregion
#region post

 [HttpPost]
     public async  Task<ActionResult>  Post(Product product)
      {
        
          _socialContext.products.AddAsync(product);
          await  _socialContext.SaveChangesAsync();


          return CreatedAtAction(nameof(Get),new {id = product.ProductID},product);

      }

      #endregion
#region put

      [HttpPut("{id}")]
     public async  Task<ActionResult>  put (int id,Product product)
      {

        Console.WriteLine("girdi içeri");
        if(id!=product.ProductID)
        {

            return BadRequest();
            
        }
        else
        {    
        var p = await _socialContext.products.Where(x=>x.ProductID==id).FirstOrDefaultAsync(); // METHODLAR ASENKRON 
        if(p==null)
        {

            return NotFound();
        }
        else
        {
         p.Names=product.Names;
         p.Price=product.Price;
         p.IsActive=product.IsActive;
          
          try 
          {
           await _socialContext.SaveChangesAsync();
           }
           catch(Exception e )
           {

                  return NotFound();
           }


          return CreatedAtAction(nameof(Get),new {id = product.ProductID},product);
          }
          }
          

      }

#endregion
#region delete
[HttpDelete("{id}")]
     public async  Task<ActionResult>  delete(int id)
      {

        Console.WriteLine("girdim buradayım ");
        
          var sil  = await _socialContext.products.FindAsync(id);
                        _socialContext.Remove(sil);
          await  _socialContext.SaveChangesAsync();


            

          return Ok();

      }
#endregion



    }
    
}