namespace REM_POD_App.files
{
    public interface IModelRepository
    {
        public Model GetById(int id);
        public IEnumerable<Model> GetAll(string category);

        public Model Add(Model model);

        public Model Delete(int id);
    }
}
