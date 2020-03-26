using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MindPalace.Interface;
//using Autofac;
//using ks.dotnetbase.standardutilities.Interface;
//using MindPalace.Infrastructure;

namespace MindPalace.UnitTest.Core
{

    /// <summary>
    /// The base class for Unit tests. As a base class it provides just a minimum of common functionality
    /// </summary>
    [TestClass]
    public class BaseTestClass
    {
        private TestContext _testContextInstance;
        //private IMindPalaceApi _mindPalaceApi;
        //protected IMindPalaceApi mindPalaceApi => _mindPalaceApi??(_mindPalaceApi = AppContainer.Container.Resolve<IMindPalaceApi>());

        //private IRuntimeEnvironment _runtimeEnvironment;
        //protected IRuntimeEnvironment runtimeEnvironment => _runtimeEnvironment ?? (_runtimeEnvironment = AppContainer.Container.Resolve<IRuntimeEnvironment>());

        public BaseTestClass()
        {
            // Initialize the logger in the logging factory with the mock logger so that
            // Logging calls don't cause a null object exception
            // Also, we'll be able to monitor and test against log entry creation
            // Initialize the bootstrapper. This will be used to Mock those items that are 
            // instantiated via IoC
            var bootstrapper = new Bootstrapper();

            RegisterClassSpecificDependencies(bootstrapper);

         //   AppContainer.Container = bootstrapper.CreateContainer(); 
        }

        protected virtual void RegisterClassSpecificDependencies(Bootstrapper bootstrapper)
        {
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }
    }



}
