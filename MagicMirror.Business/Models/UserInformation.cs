using MagicMirror.Business.Enums;

namespace MagicMirror.Business.Models
{
    public sealed class UserInformation: Model
    {
        // Singleton pattern
        private static UserInformation _instance;
        private static readonly object Padlock = new object();

        private UserInformation() { }

        public static UserInformation Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserInformation();
                    }

                    return _instance;
                }
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string WorkAddress { get; set; }

        public TemperatureUom TemperatureUom { get; set; }

        public DistanceUom DistanceUom { get; set; }

        public override void ConvertValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
