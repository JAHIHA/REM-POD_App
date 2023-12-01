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
    public class RepositoryTests
    {
        private ModelRepository _Mrepository;
        private readonly Model _badModel = new Model() { Id = 10, Temperature = 31, Distance = 301, Magnetometer = -16 };
        [TestInitialize]
        public void Init()
        {
            _Mrepository = new ModelRepository(null); 
        }
        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_Mrepository.GetById(2));
            Assert.IsNotNull(_Mrepository.GetById(3));
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Model> models = _Mrepository.GetAll();
            Assert.AreEqual(5, models.Count());
            IEnumerable<Model> orderByTime = _Mrepository.GetAll(orderBy: "TimeStamp-asc");
            Assert.AreEqual(22, orderByTime.First().Temperature);
            IEnumerable<Model> orderByTemp = _Mrepository.GetAll(orderBy: "Temperature-asc");
            Assert.AreEqual(2, orderByTemp.First().Magnetometer);

            IEnumerable<Model> defaultCase = _Mrepository.GetAll(orderBy: "InvalidOrder");
            Assert.IsNotNull(defaultCase);

        }

        [TestMethod()]
        public void AddTest()
        {
            Model model = new Model() { Id = 7, TimeStamp = DateTime.Now, Temperature = 17, Magnetometer = 5, Distance = 7 };
            Assert.AreEqual(7, _Mrepository.Add(model).Id);
            Assert.AreEqual(7, _Mrepository.GetAll().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _Mrepository.Add(_badModel));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Model model = new Model() { Id = 3, TimeStamp = DateTime.Now, Temperature = 16, Magnetometer = 4, Distance = 2 };
            Assert.IsNull(_Mrepository.Update(88, model)); 
            Assert.AreEqual(2, _Mrepository.Update(2, model).Id);
            Assert.AreEqual(5, _Mrepository.GetAll().Count());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _Mrepository.Update(1, _badModel));
        }
    }
}