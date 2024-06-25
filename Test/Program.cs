using Test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Text("OK"));
app.MapGet("/skiasharp", () =>
{
    using var image = TestSkiaSharp.CreateImage("SkiaSharp") ;
    return Results.File(image.ToArray(), "image/png");
});
app.MapGet("/xls", () =>
{

    try
    {
        var image = TestFreeSpire.FromXls();
        return Results.File(image, "image/png");
    }
    catch(Exception ex)
    {
        var text = ex.Message +Environment.NewLine;
        text += ex.StackTrace;
        return Results.Text(text);
    }
    
});
app.Run();