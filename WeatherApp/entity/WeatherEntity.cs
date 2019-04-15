using System;
using SQLite;

namespace WeatherApp.model
{
    /*
     * {"coord":{"lon":139,"lat":35},
"sys":{"country":"JP","sunrise":1369769524,"sunset":1369821049},
"weather":[{"id":804,"main":"clouds","description":"overcast clouds","icon":"04n"}],
"main":{"temp":289.5,"humidity":89,"pressure":1013,"temp_min":287.04,"temp_max":292.04},
"wind":{"speed":7.31,"deg":187.002},
"rain":{"3h":0},
"clouds":{"all":92},
"dt":1369824698,
"id":1851632,
"name":"Shuzenji",
"cod":200}
     * 
     */
    public struct WeatherEntity
    {
        [PrimaryKey]
        public string City { get; set; }
        public string CityLocal { get; set; }
        public string Country { get; set; } 
        public double Temperature { get; set; }
        public long Dt { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Wind { get; set; }
        public double Preseure { get; set; }
        public double Cloud { get; set; }

    }
}
