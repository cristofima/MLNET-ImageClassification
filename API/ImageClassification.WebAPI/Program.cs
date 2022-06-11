using ImageClassification.WebAPI.DataModels;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPredictionEnginePool<PlantDiseaseModelInput, PlantDiseaseModelOutput>()
    .FromFile(modelName: "ImageClassification.MLModels.PlantDiseaseClassificationMLModel", filePath: "MLModels/PlantDiseaseClassificationMLModel.zip", watchForChanges: true);

builder.Services.AddPredictionEnginePool<SimpsonsCharactersModelInput, SimpsonsCharactersModelOutput>()
    .FromFile(modelName: "ImageClassification.MLModels.SimpsonsCharactersClassificationMLModel", filePath: "MLModels/SimpsonsCharactersClassificationMLModel.zip", watchForChanges: true);

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
}

app.UseHttpsRedirection();

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
