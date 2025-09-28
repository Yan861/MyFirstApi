var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var prop = builder.Configuration.GetSection("Prop1").Value; // para acessar valores no appsettings.json

var warning = builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Default").Value;
// para acessar propriedades de objetos complexos é necessario mais de uma chamada

warning = builder.Configuration.GetValue<string>("Logging:LogLevel:Default");
// também pode ser acessado desse jeito

var myClass = builder.Configuration.GetSection("MyClass").Get<MyFirstApi.MyClass>();
// tambem pode ser chamado diretamente para um objeto, ele vai até o appSettings e da mais preferencia para o mais especifico, ou seja
// caso o mesmo objeto esteja no appSettings e no appSettings.Dev, ele vai sobreescrever com os valores do .Dev

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
