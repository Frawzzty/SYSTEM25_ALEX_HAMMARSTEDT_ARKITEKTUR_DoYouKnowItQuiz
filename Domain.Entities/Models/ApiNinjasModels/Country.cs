
using System.Text.Json.Serialization;

namespace Domain.Entities.Models.ApiNinjasModels; //Close to remove namespace måswings

public class Country
{
    [JsonPropertyName("country")]
    public string CountryISO2 { get; set; } = string.Empty;

    [JsonPropertyName("square_image_url")]
    public string SquareImageUrl { get; set; } = string.Empty;
    [JsonPropertyName("rectangle_image_url")]
    public string RectangleimageUrl { get; set; } = string.Empty;

}
