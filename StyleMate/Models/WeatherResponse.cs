using System.Text.Json.Serialization;

public class WeatherResponse
{
    public Coord? Coord { get; set; }
    public List<Weather>? Weather { get; set; }
    public string? Base { get; set; }
    public Main? Main { get; set; }
    public int Visibility { get; set; }
    public Wind? Wind { get; set; }
    public Clouds? Clouds { get; set; }
    public Rain? Rain { get; set; } // Nullable
    public Snow? Snow { get; set; } // Nullable
    public long Dt { get; set; }
    public Sys? Sys { get; set; }
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Cod { get; set; }
}

public class Coord
{
    public float Lon { get; set; }
    public float Lat { get; set; }
}

public class Weather
{
    public int Id { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}

public class Main
{
    public float Temp { get; set; }
    public float FeelsLike { get; set; }
    public float TempMin { get; set; }
    public float TempMax { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public int? SeaLevel { get; set; } // Nullable
    public int? GrndLevel { get; set; } // Nullable
}

public class Wind
{
    public float Speed { get; set; }
    public int Deg { get; set; }
    public float? Gust { get; set; } // Nullable
}

public class Clouds
{
    public int All { get; set; }
}

public class Rain
{
    [JsonPropertyName("1h")]
    public float? OneHour { get; set; } // Nullable
}

public class Snow
{
    [JsonPropertyName("1h")]
    public float? OneHour { get; set; } // Nullable
}

public class Sys
{
    public int? Type { get; set; } // Nullable
    public int? Id { get; set; } // Nullable
    public string Country { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}
