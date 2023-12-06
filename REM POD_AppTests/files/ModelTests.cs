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
        private Model validmodel = new Model {Id = 1, Temperature = 20.5, Magnetometer = 91.23, Distance = 3};



        private Model tooHotModel = new Model { Id = 2, Temperature = 30.1, Magnetometer = 80.53, Distance = 3 };
        private Model tooColdModel = new Model { Id = 3, Temperature = -10.1, Magnetometer = 51.43, Distance = 3 };
        private Model validTempModel = new Model { Id = 4, Temperature = 20.1, Magnetometer = 31.43, Distance = 3 };


        private Model validDistModel = new Model { Id = 5, Temperature = 15.1, Magnetometer = 11.43, Distance = 3 };
        private Model tooCloseModel = new Model { Id = 6, Temperature = 18.1, Magnetometer = 12.43, Distance = 2 };



        [TestMethod()]
        public void ToStringTest()
        {
            string str = validmodel.ToString();
            Assert.AreEqual("Id = 1, Temperature = 20,5, Magnetometer = 91,23, Distance = 3", str);
        }

       

        [TestMethod()]
        public void ValidateTemperature()
        {
            // test +30 og -10 temperatur
            validTempModel.ValidateTemp();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tooHotModel.ValidateTemp());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tooColdModel.ValidateTemp());


        }

        [TestMethod()]
        public void ValidateDistance()
        {
            
            validDistModel.ValidateDist();
            Assert.ThrowsException<ArgumentException>(() => tooCloseModel.ValidateDist());

        }

        [TestMethod()]
        public void ValidateTest()
        {
            validmodel.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tooHotModel.ValidateTemp());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => tooColdModel.ValidateTemp());
            Assert.ThrowsException<ArgumentException>(() => tooCloseModel.ValidateDist());
        }

    }
}