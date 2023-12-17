var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/merhaba/", Merhaba);

app.MapGet("topla/{s1}/{s2}", (int s1, int s2) =>
{
    return Topla(s1, s2);
});

app.Run();



string Merhaba()
{
    return "Merhaba FFS103";
}

string Topla(int s1, int s2)
{
    return $"Sonuç: {s1 + s2}";
}
