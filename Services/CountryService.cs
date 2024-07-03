using AEDProject.Entities;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Repositories;
using AEDProject.ViewModels;
using System.Runtime.Intrinsics.Arm;

namespace AEDProject.Services
{
	public class CountryService : ICountryService
	{
		private readonly ICountryRepo _countryRepo;
		private readonly IDocTypeRepo _docTypeRepo;
		public CountryService(ICountryRepo countryRepo, IDocTypeRepo docTypeRepo)
		{
			_countryRepo = countryRepo;
			_docTypeRepo = docTypeRepo;
		}

		public void Add(CountryViewModel model)
		{
			Country country = new Country
			{
				Name = model.Name,
			};

			var docTypes = _docTypeRepo.GetAll()
				.Where(p => model.DocTypeIds.Contains(p.Id)).ToList();


			country.DocumentTypes = docTypes;
			_countryRepo.Add(country);
			_countryRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = _countryRepo.GetById(id);
			_countryRepo.Delete(entity);
		}

		public List<CountryViewModel> GetAllCountries()
		{
			var data = _countryRepo.GetAll();
			var countryList = data.Select(d => new CountryViewModel
			{
				Id = d.Id,
				Name = d.Name,
				DocTypeName = String.Join(",", d.DocumentTypes.Select(c => c.Name)),
				DocTypeIds = d.DocumentTypes.Select(d => d.Id).ToList(),
			}).ToList();
			return countryList;
		}

		public CountryViewModel GetById(int? Id)
		{
			var country = _countryRepo.GetById(Id);
			return new CountryViewModel
			{
				Id = country.Id,
				Name = country.Name,
				DocTypeName = String.Join(",", country.DocumentTypes.Select(c => c.Name)),
				DocTypeIds = country.DocumentTypes.Select(d => d.Id).ToList(),
			};
		}

		public void Update(CountryViewModel model)
		{
			

			var types =  _docTypeRepo.GetAll()
				.Where(p=> model.DocTypeIds.Contains(p.Id)).ToList();
			var docTypeEntity = _countryRepo.GetById(model.Id);

			docTypeEntity.Name = model.Name;
			
			docTypeEntity.DocumentTypes.Clear();
			_docTypeRepo.SaveChanges();
			docTypeEntity.DocumentTypes = types;
			//_docTypeRepo.AttachRange(docTypes);
			_docTypeRepo.SaveChanges();
		}
	}
}
