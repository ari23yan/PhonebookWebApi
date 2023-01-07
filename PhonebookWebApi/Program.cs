using PhonebookWebApi.Data.Context;
using PhonebookWebApi.Repository.Impelementation;
using PhonebookWebApi.Repository.Interfaces;
using PhonebookWebApi.Services.Impelementation;
using PhonebookWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using PhonebookWebApi.Repositories.Interfaces;
using PhonebookWebApi.Repositories.Impelementation;
using PhonebookWebApi.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<PhoneBookWebApiDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"));
});
builder.Services.AddScoped<IContactRepository,ContactRepository>();
builder.Services.AddScoped<IContactServices, ContactServices>();
builder.Services.AddScoped(typeof(IGenerciRepository<>), typeof(GenericRepository<>));
builder.Services.AddControllersWithViews();
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
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
