//using Autofac;
//using ks.dotnetbase.standardutilities.Interface;
//using ks.infrastructure.logging;
//using MindPalace.Database;
//using MindPalace.MockObjects;
//using MindPalace.MockObjects.Mocks;
//using MindPalace.MockObjects.Services;
//using MindPalace.Services.Interface;
//using MindPalace.MockObjects.TestData;
//using MindPalace.Services;
//using MindPalace.Interface;
//using MindPalace.Services.Implementation;
//using MindPalace.Implementation;
//using ks.infrastructure.analytics;
//using MindPalace.Infrastructure.Mocks;

namespace MindPalace.UnitTest.Core
{
    public class Bootstrapper 
    {
        public Bootstrapper()
        {
            //if (containerBuilder == null)
            //{
            //    //// Create the container builder
            //    //containerBuilder = new ContainerBuilder();

            //    //// initialize the logging factory here
            //    //LoggingFactory.Initialize(new MockLogger());
            //    //AnalyticsFactory.Initialize(new MockAnalytics());

            //    RegisterDependencies();
            //}
        }
        //public static Autofac.IContainer Container { get; set; }
        //public ContainerBuilder containerBuilder;
        //protected RuntimeEnvironmentMock RuntimeEnvironmentMock = new RuntimeEnvironmentMock();

        //public IContainer CreateContainer()
        //{
        //    Container = containerBuilder.Build();

        //    return Container;
        //}

        //public LocatorMock LocatorMockInstance => new LocatorMock();
        ////public MockComputerVisionFactory ComputerVisionFactory => new MockComputerVisionFactory();
        //public ComputerVisionFactory ComputerVisionFactory => new ComputerVisionFactory();

        /// <summary>
        /// Register dependency injection for the unit tests
        /// </summary>
        protected virtual void RegisterDependencies()
        {
            //var builder = containerBuilder;


            //builder.RegisterType<MockLocationRepo>().As<ILocationRepo>();

            //builder.RegisterInstance(LocatorMockInstance).As<Plugin.Geolocator.Abstractions.IGeolocator>();

            //builder.RegisterType<SettingsMock>().As<Plugin.Settings.Abstractions.ISettings>();

            //builder.RegisterInstance(RuntimeEnvironmentMock).As<IRuntimeEnvironment>();

            //builder.RegisterInstance(ComputerVisionFactory).As<IComputerVisionFactory>();

            //builder.RegisterType<LocationService>().As<ILocationService>();
            //builder.RegisterType<MemoryService>().As<IMemoryService>();
            //builder.RegisterType<VisionService>().As<IVisionService>();

            //builder.RegisterInstance(DataAccess.Instance().MindPalaceApi()).As<IMindPalaceApi>();
            ////builder.RegisterType<MindPalace.Implementation.MindPalaceApi>().As<Interfaces.IMindPalaceApi>();
        }
    }
}
