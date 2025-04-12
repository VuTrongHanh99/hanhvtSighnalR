using SignalR.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Thêm SignalR
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// S? d?ng CORS tr??c khi map hub
app.UseCors("AllowAngularClient");
app.MapHub<SignalRHub>("/signalrHub").RequireCors("AllowAngularClient");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
