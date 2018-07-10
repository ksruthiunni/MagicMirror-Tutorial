using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Entities.Weather
{
    public class WeatherEntity : Entity
    {
        public Coord Coord { get; set; }
        public virtual Weather[] Weather { get; set; }
        public string _base { get; set; }
        public virtual Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public virtual Sys Sys { get; set; }
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public int Cod { get; set; }
    }
}