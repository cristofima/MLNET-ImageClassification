using System.ComponentModel.DataAnnotations;

namespace ImageClassification.WebAPI.Requests
{
    public class BaseRequest
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
