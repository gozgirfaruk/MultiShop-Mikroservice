using MultiShop.OrderApplication.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.OrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.OrderApplication.Interfaces;
using MultiShop.OrderApplication.Services;
using MultiShop.OrderPersistance.Context;
using MultiShop.OrderPersistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region Address
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();
#endregion

#region OrderDetail
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<RemoveOrderDetailQueryHandler>();
builder.Services.AddScoped<UpdateOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
#endregion


builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddDbContext<OrderContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
