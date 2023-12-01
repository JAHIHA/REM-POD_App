using static System.Reflection.Metadata.BlobBuilder;

namespace REM_POD_App.files
{
    public class ModelRepository
    {
        private readonly List<Model> _models = new List<Model>
        {
            new Model(1,DateTime.Now,22,5,2),
            new Model(2,DateTime.Now,18,10,1),
            new Model(3,DateTime.Now,0,11,3),
            new Model(4,DateTime.Now,12,7,2),
            new Model(5,DateTime.Now,-2,2,1),
        };
        
        public Model GetById(int id)
        {
            return _models.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Model> GetAll(string? orderBy= null)
        {
            IEnumerable<Model> result = new List<Model>(_models);
            if (orderBy != null)
            {
                orderBy= orderBy.ToLower();
                switch(orderBy)
                {
                    case "TimeStamp":
                    case "TimeStamp-asc": 
                        result = result.OrderBy(_models => _models.TimeStamp);
                        break;
                    case "timeStamp-desc": 
                        result= result.OrderByDescending(_models => _models.TimeStamp);
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
            return result; 

        }
        public Model Add(Model model)
        {
            // TODO 
            //model.Validation();
            _models.Add(model);
            return model;
        }
        public Model Update(int id, Model model)
        {
            model.Validate(); 
            Model existingModel= GetById(id);
            if(existingModel==null)
            {
                return null; 

            }
            existingModel.TimeStamp = DateTime.Now;
            existingModel.Temperature = model.Temperature;
            existingModel.Magnetometer = model.Magnetometer;
            existingModel.Distance = model.Distance;
            return existingModel;
        }

    }
}
