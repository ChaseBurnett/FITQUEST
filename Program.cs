using FITQUEST.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IChallenegeRepository, ChallenegeRepository>();
builder.Services.AddTransient<IUserChallengesRepository, UserChallengesRepository>();
builder.Services.AddTransient<IChallengeCheckInRepository, ChallengeCheckInRepository>();
builder.Services.AddTransient<ILeaderBoardRepository, LeaderBoardRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(options =>
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
