namespace MagicMirror.DataAccess.Entities.Entities
{
    public class UserEntity: Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string WorkAddress { get; set; }

        public int TemperatureUom { get; set; }

        public int DistanceUom { get; set; }
    }
}
