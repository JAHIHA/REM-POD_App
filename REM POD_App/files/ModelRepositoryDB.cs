using REM_POD_App.DBcontext;

namespace REM_POD_App.files
{
    public class ModelRepositoryDB: IModelRepository
    {

        private readonly REMcontext _db;

        public ModelRepositoryDB(REMcontext db)
        {
            db.Database.EnsureCreated();
            _db = db;
        }


        public Model GetById(int id)
        {

            return _db.Models.FirstOrDefault(x => x.Id == id);
            
        }
        public IEnumerable<Model> GetAll(string? orderBy = null)
        {
            IQueryable<Model> result = _db.Models;
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "TimeStamp":
                    case "TimeStamp-asc":
                        result = result.OrderBy(_models => _models.TimeStamp);
                        break;
                    case "timeStamp-desc":
                        result = result.OrderByDescending(_models => _models.TimeStamp);
                        break;

                    case "Temperature":
                    case "Temperature-asc":
                        result = result.OrderBy(_models => _models.Temperature);
                        break;
                    case "Temperature-desc":
                        result = result.OrderByDescending(_models => _models.Temperature);
                        break;

                    case "Magnetometer":
                    case "Magnetometer -asc":
                        result = result.OrderBy(_models => _models.Magnetometer);
                        break;
                    case "Magnetometer -desc":
                        result = result.OrderByDescending(_models => _models.Magnetometer);
                        break;

                    case "Distance":
                    case "Distance-asc":
                        result = result.OrderBy(_models => _models.Distance);
                        break;
                    case "Distance-desc":
                        result = result.OrderByDescending(_models => _models.Distance);
                        break;
                    default:
                        break;
                }
            }
            return result.ToList();

        }
        public Model Add(Model model)
        {

            model.Validate();
            _db.Models.Add(model);
            _db.SaveChanges();
            return model;
        }
        public Model Delete(int id)
        {
            Model model = GetById(id);
            if (model == null)
            {
                return null;
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return model;
        }

    }

}
