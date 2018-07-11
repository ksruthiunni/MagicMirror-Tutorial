﻿using System;

namespace MagicMirror.Business.Models
{
    public class TrafficModel: Model
    {
        public string Start  { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public int Duration { get; set; }

        public DateTime TimeOfArrival { get; set; }

        public DistanceUom DistanceUom { get; set; }

        public override void ConvertValues()
        {
            throw new NotImplementedException();
        }
    }

    public enum DistanceUom
    {
        Metric = 0,
        Imperial = 1
    }
}
