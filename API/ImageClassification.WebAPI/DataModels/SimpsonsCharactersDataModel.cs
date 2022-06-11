using Microsoft.ML.Data;

namespace ImageClassification.WebAPI.DataModels
{

    public class SimpsonsCharactersModelInput
    {
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }
    }

    public class SimpsonsCharactersModelOutput
    {
        [ColumnName(@"PredictedLabel")]
        public string PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
