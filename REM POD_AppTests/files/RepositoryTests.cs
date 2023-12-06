using Microsoft.VisualStudio.TestTools.UnitTesting;
using REM_POD_App.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            _Mrepository = new ModelRepository(); 
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
        public void DeleteTest()
        {
            
            IEnumerable<Model> models = _Mrepository.GetAll();

            
            Assert.IsNotNull(models);
            Assert.AreEqual<bool>(true, models.Count() > 0);

            
            Model somemodel = models.First<Model>();
            int numOfModels = models.Count();

            
            Model? deletedModel = _Mrepository.Delete(somemodel.Id);

            
            Assert.AreEqual(numOfModels - 1, _Mrepository.GetAll().Count());
            Model? modelFound = null;
            
            modelFound = _Mrepository.GetAll().FirstOrDefault(a => a.Id == deletedModel.Id);
            
            Assert.IsNull(modelFound);
        }
    }
}