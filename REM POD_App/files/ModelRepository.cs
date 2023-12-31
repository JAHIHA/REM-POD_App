﻿using REM_POD_App.DBcontext;
using static System.Reflection.Metadata.BlobBuilder;

namespace REM_POD_App.files
{
    public class ModelRepository : IModelRepository
    {

      
        private readonly List<Model> _models= new List<Model>();
        private int nextId = 0;
        

        public ModelRepository()
        {
            
        }

        
        public Model? GetById(int id)
        {
            return _models.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Model> GetAll(string? orderBy= null)
        {
            IEnumerable<Model> result = new List<Model> ();
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
            return result.ToList(); 

        }
        public Model Add(Model model)
        {
            
            model.Validate();
            nextId++;
            model.Id =nextId;
            _models.Add(model);
            return model;
        }
        public Model Delete(int id)
        {
            Model model = GetById(id);
            if (model == null)
            {
                return null;
            }
            _models.Remove(model);
            return model;
        }

    }
}
