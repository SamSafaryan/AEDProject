using AEDProject.ViewModels;

namespace AEDProject.Interfaces.Services
{
	public interface IDocTypeService
	{
		public List<DocTypeViewModel> GetAllTypes();
		public void Add(DocTypeViewModel model);
		public void Delete(int id);
		public void Update(DocTypeViewModel model);
		public DocTypeViewModel GetById(int? Id);
		public List<DocTypeViewModel> GetAllDocTypesByCountryId(int CountryId);
	}
}
