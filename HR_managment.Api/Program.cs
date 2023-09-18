using HR_managment.Infrastructure;
using HR_managment.Persistence;
using HR_Managment.Application;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(config);
builder.Services.ConfigureInfrastructureServices(config);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", policy =>
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
     );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();


/*
 * vaghti az Run estefade mikonim baghie midelware ha ejra nemishan tanha dar soorati az run estefade mikonim
 * ke akharin middleware ma bashe
 * dar gheyre in surat bayad az method "Use" estefade konim
app.Run(async (context) =>
{
    //await context.Response.WriteAsync("test m3");;
});
app.Run(btest);
Task btest(HttpContext cntx){
   await context.Response.WriteAsync("test m1");
}
******* USE *********
 app.Use(async (context,next) =>
{
    //await context..Response.WriteAsync("test m2");;
});
 
*/
app.Run();
