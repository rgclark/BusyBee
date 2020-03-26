using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusyBee.UnitTests
{
    [TestClass]
    public class WeatherServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var WeatherService = new BusyBee.Services.WeatherService();
             var weather = WeatherService.GetWeather(39.79, -105.02);
        }
    }
}
