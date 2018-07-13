namespace MagicMirror.DataAccess.Entities.Weather
{
    public class Main
    {
        public virtual double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
    }
}