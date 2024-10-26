using StudentEvents.Models;
using StudentEvents.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Allow the Angular app
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<StudentEventsDatabaseSettings>(
    builder.Configuration.GetSection("StudentEventsDatabase"));
builder.Services.AddSingleton<StudentService>();
builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<EventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins"); // Ensure this is before app.UseAuthorization()
app.UseAuthorization();
app.MapControllers();

app.Run();
