using WebWeek06_1026.Interface; // 確保命名空間正確
using WebWeek06_1026.Repositories;
using WebWeek06_1026.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 注入一個單例的 DbContext 類別來協助資料庫連線
builder.Services.AddSingleton<DbContext>();

// 將 MemberRepository 類型的實例注入到 IMember 容器中
builder.Services.AddScoped<IMember, MemberRepository>();

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
