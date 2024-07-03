
using AEDProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEDProject.Interfaces.Repositories
{
    public interface IDocumentRepo
    {
        public void Add(Document document);
        public Document GetById(int id);
        public List<Document> GetAll();
        public IQueryable<Document> GetAllQuerable();
		public void Delete(Document document);
        public void SaveChanges();
    }
}
