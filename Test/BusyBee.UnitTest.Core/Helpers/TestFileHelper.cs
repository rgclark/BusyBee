//using Autofac;
//using ks.dotnetbase.standardutilities.Interface;
//using MindPalace.MockObjects.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using MindPalace.Infrastructure;
using System.Threading.Tasks;
using System.Threading;

namespace MindPalace.UnitTest.Core.Helper
{
    public class TestFileHelper
    {
        private static string _testfileSourceFolder = "SourceTestFiles";
        public static string testfileSourceFolder => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, _testfileSourceFolder);

        //private static string _testfileDestinationFolder => ((RuntimeEnvironmentMock)runtimeEnvironment).testfileFolder;
        //public static string testfileDestinationFolder => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, _testfileDestinationFolder);

        //private static IRuntimeEnvironment _runtimeEnvironment;
        //protected static IRuntimeEnvironment runtimeEnvironment => _runtimeEnvironment ?? (_runtimeEnvironment = AppContainer.Container.Resolve<IRuntimeEnvironment>());
        //public static void CopyTestFilesFromSource(string WithSuffix="")
        //{
        //    var srcPath = testfileSourceFolder;
        //    var destPath = testfileDestinationFolder;

        //    if (!Directory.Exists(destPath))
        //    {
        //        // Create folder
        //        Directory.CreateDirectory(destPath);
        //    }
        //    if (Directory.Exists(srcPath)) {
        //        WithSuffix = WithSuffix.ToLower();
        //        foreach (var file in Directory.EnumerateFiles(srcPath))
        //        {
        //            var filename = Path.GetFileName(file).ToLower();

        //            if (!string.IsNullOrEmpty(WithSuffix))
        //            {
        //                if (Path.GetExtension(filename) == WithSuffix)
        //                    ReplaceFile(srcPath, destPath, filename);
        //            }
        //            else {
        //                ReplaceFile(srcPath, destPath, filename);
        //            }
        //        }
        //    }
        //}
        //public static void ClearTestFilesFromTempTestDirectory(string subfolder="", bool deleteTestFolder=false)
        //{
        //    var tempTestPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, _testfileDestinationFolder, subfolder);
            
        //    if (Directory.Exists(tempTestPath))
        //    {
        //        try
        //        {
        //            foreach (var file in Directory.EnumerateFiles(tempTestPath))
        //            {

        //                Thread.Sleep(1000);
        //                File.Delete(file);
        //            }
        //            if (deleteTestFolder)
        //                Directory.Delete(tempTestPath);
        //        }
        //        catch (Exception ex ) 
        //        {
        //        }
        //    }
        //}

        //public static void ReplaceFile(string srcPath, string destPath, string filename)
        //{
        //    if (string.IsNullOrEmpty(srcPath)) throw new ArgumentNullException(nameof(srcPath));
        //    if (string.IsNullOrEmpty(destPath)) throw new ArgumentNullException(nameof(destPath));
        //    if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(nameof(filename));

        //    var destFile = Path.Combine(destPath, filename);
        //    var srcFile = Path.Combine(srcPath, filename);

        //    if (File.Exists(srcFile))
        //    {
        //        //if (File.Exists(destFile))
        //        //{
        //        //    File.Delete(destFile);
        //        //}
        //        File.Copy(srcFile, destFile, true);
        //    }
        //}

    }
}
