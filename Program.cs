var builder = WebApplication.CreateBuilder(args);
Databaza.InicializujAdatbazist();
Databaza.ImportFromJson("questions.json", "answers.json");


builder.Services.AddControllers();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.Run();