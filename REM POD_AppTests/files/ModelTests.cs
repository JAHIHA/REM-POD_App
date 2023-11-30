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

        //Test objects
        private Model validmodel = new Model {Id = 1, Temperature = 20.5, MagnetometerX = -23.45, MagnetometerY = 56.78, MagnetometerZ = 91.23, Distance = 3};



        private Model tooHotModel = new Model { Id = 2, Temperature = 30.1, MagnetometerX = -22.45, MagnetometerY = 52.78, MagnetometerZ = 80.53, Distance = 3 };
        private Model tooColdModel = new Model { Id = 3, Temperature = -10.1, MagnetometerX = -34.75, MagnetometerY = 32.98, MagnetometerZ = 51.43, Distance = 3 };
        private Model validTempModel = new Model { Id = 4, Temperature = 20.1, MagnetometerX = -36.75, MagnetometerY = 38.98, MagnetometerZ = 31.43, Distance = 3 };


        private Model validDistModel = new Model { Id = 5, Temperature = 15.1, MagnetometerX = -34.75, MagnetometerY = 33.98, MagnetometerZ = 11.43, Distance = 3 };
        private Model tooCloseModel = new Model { Id = 6, Temperature = 18.1, MagnetometerX = -33.75, MagnetometerY = 44.98, MagnetometerZ = 12.43, Distance = 2 };



        [TestMethod()]
        public void ToStringTest()
        {
            string str = validmodel.ToString();
            Assert.AreEqual("Id = 1, Temperature = 20,5, MagnetometerX = -23,45, MagnetometerY = 56,78, MagnetometerZ = 91,23, Distance = 3", str);
        }

        [TestMethod()]
        public void ValidateMagnetic()
        {
            //Test nødvendigt?
        }

        [TestMethod()]
        public void ValidateTemperature()
        {
            // test +30 og -10 temperatur
            validTempModel.ValidateTemp();
            Assert.ThrowsException<ArgumentException>(() => tooHotModel.ValidateTemp());
            Assert.ThrowsException<ArgumentException>(() => tooColdModel.ValidateTemp());


        }

        [TestMethod()]
        public void ValidateDistance()
        {
            // min 3 meter
            validDistModel.ValidateDist();
            Assert.ThrowsException<ArgumentException>(() => tooCloseModel.ValidateDist());

        }
    }
}