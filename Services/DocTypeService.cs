using AEDProject.Entities;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Repositories;
using AEDProject.ViewModels;
using System.Data;

namespace AEDProject.Services
{
	public class DocTypeService : IDocTypeService
	{
		private readonly IDocTypeRepo _DoctypeRepo;
		private readonly ICountryRepo _CountryRepo;
		public DocTypeService(IDocTypeRepo doctypeRepo, ICountryRepo countryRepo)
		{
			_DoctypeRepo = doctypeRepo;
			_CountryRepo = countryRepo;
		}

		public void Add(DocTypeViewModel model)
		{
			DocumentType type = new DocumentType
			{
				Name = model.Name,
			};

			var doctypes = _CountryRepo.GetAll()
				.Where(d => model.CountryIds.Contains(d.Id)).ToList();


			type.Countries = doctypes;

			_DoctypeRepo.Add(type);
			_DoctypeRepo.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = _DoctypeRepo.GetById(id);
			_DoctypeRepo.Delete(entity);
		}

		public List<DocTypeViewModel> GetAllDocTypesByCountryId(int CountryId)
		{
			var data = _CountryRepo.GetAll()
				.Where(p=>p.Id == CountryId)
				.SelectMany(p=>p.DocumentTypes)
				.ToList();
			var typeList = data.Select(d => new DocTypeViewModel
			{
				Id = d.Id,
				Name = d.Name,

			}).ToList();
			return typeList;
		}

		public List<DocTypeViewModel> GetAllTypes()
		{
			var data = _DoctypeRepo.GetAll();
			var typeList = data.Select(d => new DocTypeViewModel
			{
				Id = d.Id,
				Name = d.Name,
				CountryName = String.Join(",", d.Countries.Select(c => c.Name)),
                CountryIds = d.Countries.Select(c => c.Id).ToList()
            }).ToList();
			return typeList;
		}

		public DocTypeViewModel GetById(int? Id)
		{
			var doctype = _DoctypeRepo.GetById(Id);
			return new DocTypeViewModel
			{
				Id = doctype.Id,
				Name = doctype.Name,
				CountryName = String.Join(",", doctype.Countries.Select(c => c.Name)),
				CountryIds = doctype.Countries.Select(c => c.Id).ToList()
            };
		}

		public void Update(DocTypeViewModel model)
		{
			var countries = _CountryRepo.GetAll()
				.Where(d => model.CountryIds.Contains(d.Id)).ToList();
			var countryEntity = _DoctypeRepo.GetById(model.Id);

			countryEntity.Name = model.Name;
			
			countryEntity.Countries.Clear();
			_CountryRepo.SaveChanges();
			countryEntity.Countries = countries;
			//_CountryRepo.AttachRange(countries);
			_CountryRepo.SaveChanges();
		}
	}
}
