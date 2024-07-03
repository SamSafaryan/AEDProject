using AEDProject.Entities;
using AEDProject.Entities.Data;
using AEDProject.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AEDProject.Repositories
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly AEDContext _context;
        public DocumentRepo(AEDContext context)
        {
            _context = context;
        }
        public void Add(Document document)
        {
            _context.Documents.Add(document);
            SaveChanges();
        }

        public void Delete(Document document)
        {
            _context.Documents.Remove(document);
            SaveChanges();
        }

        public List<Document> GetAll()
        {
            return _context.Documents.Include(p=>p.Country)
                .Include(p=>p.Images).Include(p=>p.DocumentType).ToList();
        }

		public IQueryable<Document> GetAllQuerable()
		{
			return _context.Documents.AsQueryable();
		}

		public Document GetById(int id)
        {
            return _context.Documents.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
