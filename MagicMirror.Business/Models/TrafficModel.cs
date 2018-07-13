using System;
using Acme.Generic.Helpers;
using MagicMirror.Business.Enums;

namespace MagicMirror.Business.Models
{
    public class TrafficModel : Model
    {
        public string Start { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public int Duration { get; set; }

        public DateTime TimeOfArrival { get; set; }

        public DistanceUom DistanceUom { get; set; }

        public override void ConvertValues()
        {
            switch (DistanceUom)
            {
                case DistanceUom.Imperial:
                    Distance = DistanceHelper.KiloMetersToMiles(Distance);
                    break;
                case DistanceUom.Metric:
                    Distance = DistanceHelper.MilesToKiloMeters(Distance);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(DistanceUom), DistanceUom, null);
            }
        }
    }
}