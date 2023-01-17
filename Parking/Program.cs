var builder = WebApplication.CreateBuilder(args);

// KESTREL
builder.WebHost.UseKestrel(o =>
{
    o.ListenAnyIP(9999);
});

// CORS
// builder.Services.AddCors();
// RATE LIMIT
// builder.Services.AddRateLimiter();
// CACHE
// builder.Services.AddMemoryCache();

builder.Services.AddDbContext<DataAccess.ParkingContext>(opt => { 
    _ = opt.UseSqlServer(builder.Configuration.GetConnectionString("parkingdb")!);
});

builder.Services.AddSingleton(typeof(DataAccess.DASQLServer));
builder.Services.AddScoped(typeof(DataAccess.EFSQLServer));
builder.Services.AddSingleton(typeof(DataAccess.SPSQLServer));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseParkingMiddleware();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
