using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using WebApiWithOData;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Person>("Persons");

modelBuilder.EntitySet<PersonDto>("PersonDto");

modelBuilder.EntitySet<Department>("Departments");

builder.Services.AddDbContext<PersonDbContext>(options =>
{
    options.UseSqlServer("Data Source=localhost;Initial Catalog=TestPersonDb;Integrated Security=True;Trust Server Certificate=True");
});

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
    "odata",
        modelBuilder.GetEdmModel()));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseODataRouteDebug();

app.UseRouting();

app.MapControllers();



app.Run();
