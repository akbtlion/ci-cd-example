var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// GET UTC
//app.MapGet("time/utc", () => Results.Ok(DateTime.UtcNow));
app.MapGet("time/cet", () => Results.Ok(TimeZoneInfo.ConvertTimeFromUtc(
    DateTime.UtcNow, 
    TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")
)));

await app.RunAsync();
