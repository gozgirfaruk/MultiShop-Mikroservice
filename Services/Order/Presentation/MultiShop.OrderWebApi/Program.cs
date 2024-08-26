using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.OrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderApplication.Services;
using MultiShop.OrderPersistance.Context;
using MultiShop.OrderPersistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOrder";
    opt.RequireHttpsMetadata = false; 
});



#region OrderDetail
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<RemoveOrderDetailQueryHandler>();
builder.Services.AddScoped<UpdateOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
#endregion


builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderingRepository),typeof(OrderingRepository));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddDbContext<OrderContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
