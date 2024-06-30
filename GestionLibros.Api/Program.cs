using GestionLibros.Persistence;
using GestionLibros.Repositories;
using GestionLibros.Services.Implementation;
using GestionLibros.Services.Interface;
using GestionLibros.Services.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register or configuring my content 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});



// Add services to the container.
builder.Services.AddTransient<IClientesRepository,ClientesRepository>();
builder.Services.AddTransient<IClientesService, ClientesService>();
builder.Services.AddTransient<ILibrosRepository, LibrosRepository>();
builder.Services.AddTransient<ILibrosService, LibrosService>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IPedidoService, PedidoService>();
builder.Services.AddAutoMapper(config =>
{
    //configurar perfiles de mapeo
    config.AddProfile<ClientesProfile>();
    config.AddProfile<LibrosProfile>();
    config.AddProfile<PedidoProfile>();

});

//cors



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var corsPolicyName = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(corsPolicyName);  // Use the CORS policy

app.MapControllers();

app.Run();
