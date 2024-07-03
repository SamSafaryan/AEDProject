using AEDProject.ViewModels;

namespace AEDProject.Interfaces.Services
{
	public interface ICountryService
	{
		public List<CountryViewModel> GetAllCountries();
		public void Add(CountryViewModel model);
		public void Delete(int id);
		public void Update(CountryViewModel model);
		public CountryViewModel GetById(int? Id);
	}
}

