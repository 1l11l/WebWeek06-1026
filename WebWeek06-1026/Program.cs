using WebWeek06_1026.Interface; // �T�O�R�W�Ŷ����T
using WebWeek06_1026.Repositories;
using WebWeek06_1026.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �`�J�@�ӳ�Ҫ� DbContext ���O�Ө�U��Ʈw�s�u
builder.Services.AddSingleton<DbContext>();

// �N MemberRepository ��������Ҫ`�J�� IMember �e����
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
