namespace MagicMirror.DataAccess.Entities.Weather
{
    public class Weather
    {
        public int Id { get; set; }
        public virtual string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}