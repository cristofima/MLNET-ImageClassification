using Microsoft.ML.Data;

namespace ImageClassification.WebAPI.DataModels
{
    public class PlantDiseaseModelInput
    {
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }
    }

    public class PlantDiseaseModelOutput
    {
        [ColumnName(@"PredictedLabel")]
        public string PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
