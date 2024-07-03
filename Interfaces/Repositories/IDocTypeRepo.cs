using AEDProject.Entities;

namespace AEDProject.Interfaces.Repositories
{
	public interface IDocTypeRepo
	{
		public void Add(DocumentType type);
		public void ChangeTracking(DocumentType type);
		public void AttachRange(List<DocumentType> types);
		public DocumentType GetById(int? id);
		public List<DocumentType> GetAll();
		public void Delete(DocumentType type);
		public void SaveChanges();
	}
}
