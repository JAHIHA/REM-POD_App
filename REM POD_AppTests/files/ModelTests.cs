using Microsoft.VisualStudio.TestTools.UnitTesting;
using REM_POD_App.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REM_POD_App.files.Tests
{
    [TestClass()]
    public class ModelTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();


        }

        [TestMethod()]
        public void ValidateMagnetic()
        {
            // - 16 
        }

        [TestMethod()]
        public void ValidateTemperature()
        {
            // test +30 og -10 temperatur
        }

        [TestMethod()]
        public void ValidateDistance()
        {
            // 3 meter
        }
    }
}