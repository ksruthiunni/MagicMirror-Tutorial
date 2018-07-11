using System;
using Acme.Generic.Helpers;

namespace MagicMirror.Business.Models
{
    public class WeatherModel : Model
    {
        public string Location { get; set; }

        public string Icon { get; set; }

        public double Temperature { get; set; }

        public string WeatherType { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public TemperatureUom TemperatureUom { get; set; }

        public WeatherModel ConvertValues()
        {
            ConvertTemperature(Temperature);
            ConvertDates();

            return this;
        }

        private void ConvertDates()
        {
            int.TryParse(Sunset, out int sunset);
            int.TryParse(Sunrise, out int sunrise);
            Sunset = DateHelper.ConvertFromUnixTimestamp(sunset).ToShortTimeString();
            Sunrise = DateHelper.ConvertFromUnixTimestamp(sunrise).ToShortTimeString();
        }

        private void ConvertTemperature(double degrees)
        {
            double convertedDegrees = -1;

            switch (TemperatureUom)
            {
                case TemperatureUom.Celsius:
                    convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    break;

                case TemperatureUom.Fahrenheit:
                    convertedDegrees = TemperatureHelper.KelvinToCelsius(degrees);
                    break;

                case TemperatureUom.Kelvin:
                    convertedDegrees = degrees;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(TemperatureUom), TemperatureUom, null);
            }

            Temperature = convertedDegrees;
        }
    }
}

public enum TemperatureUom
{
    Kelvin = 0,
    Fahrenheit = 1,
    Celsius = 2
}
