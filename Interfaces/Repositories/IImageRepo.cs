using AEDProject.Entities;

namespace AEDProject.Interfaces.Repositories
{
    public interface IImageRepo
    {
        public void Add(Image image);
        public Image GetById(int id);
        public List<Image> GetAll();
        public void Delete(Image image);
        public void SaveChanges();
    }
}
