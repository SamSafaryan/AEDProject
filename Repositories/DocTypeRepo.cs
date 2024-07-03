using AEDProject.Entities;
using AEDProject.Entities.Data;
using AEDProject.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AEDProject.Repositories
{
	public class DocTypeRepo : IDocTypeRepo
	{
		private readonly AEDContext _context;
		public DocTypeRepo(AEDContext context)
		{
			_context = context;
		}
		public void Add(DocumentType type)
		{
			_context.DocumentTypes.Add(type);
			_context.SaveChanges();
		}

		public void AttachRange(List<DocumentType> types)
		{
			_context.DocumentTypes.AttachRange(types);
		}

		public void ChangeTracking(DocumentType type)
		{
			_context.Entry(type).State = EntityState.Detached;
		}

		public void Delete(DocumentType type)
		{
			var docs = _context.Documents.Where(p => p.DocumentTypeId == type.Id).ToList();
			docs.ForEach(p => p.CountryId = null);
			_context.DocumentTypes.Remove(type);
			_context.SaveChanges();
		}

		public List<DocumentType> GetAll()
		{
			return _context.DocumentTypes.Include(p => p.Countries).ToList();
		}

		public DocumentType GetById(int? id)
		{
			return _context.DocumentTypes.Include(d => d.Countries).FirstOrDefault(p => p.Id == id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
