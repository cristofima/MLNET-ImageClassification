using ImageClassification.WebAPI.DataModels;
using ImageClassification.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace ImageClassification.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpsonsCharactersClassificationController : ControllerBase
    {
        private readonly PredictionEnginePool<SimpsonsCharactersModelInput, SimpsonsCharactersModelOutput> _predictionEnginePool;

        public SimpsonsCharactersClassificationController(PredictionEnginePool<SimpsonsCharactersModelInput, SimpsonsCharactersModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]

        public ActionResult Post([FromForm] BaseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            byte[] byteArray;
            using (var ms = new MemoryStream())
            {
                request.Image.CopyTo(ms);
                byteArray = ms.ToArray();
            }

            var input = new SimpsonsCharactersModelInput
            {
                ImageSource = byteArray
            };

            var predictionResult = _predictionEnginePool.Predict(modelName: "ImageClassification.MLModels.SimpsonsCharactersClassificationMLModel", example: input);
            var confidence = Math.Round(predictionResult.Score.Max() * 100, 2);

            return Ok(new
            {
                label = predictionResult.PredictedLabel,
                confidence = confidence
            });
        }
    }
}
