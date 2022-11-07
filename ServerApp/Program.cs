using Microsoft.EntityFrameworkCore;
using ServerApp.Data;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddDbContext<SocialContext>(x=>x.UseSqlite("Data Source=socialDb.db"));
builder.Services.AddCors(options=>{


    options.AddDefaultPolicy(
   // name:"_myAllowOrigins", add policy diyerek api adını verıp onu aşağıda use ile etkin kılarsın
   //veya defaault çakar geçersin
    builder=>{
        builder 
        .WithOrigins("http://localhost:4200","https://localhost:4200") //bu kanaldan bılgı alıcaz dıyorsun
       //  .WithMethods("GET","POST","DELETE","PUT"); // method etkin kılarsın
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
    
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseCors(_myAllowOrigins);  // örnek bu şekilde parametre alır
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
