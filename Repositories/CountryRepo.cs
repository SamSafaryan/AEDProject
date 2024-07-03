using AEDProject.Entities;
using AEDProject.Entities.Data;
using AEDProject.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AEDProject.Repositories
{
	public class CountryRepo : ICountryRepo
	{
		private readonly AEDContext _context;
		public CountryRepo(AEDContext context)
		{
			_context = context;
		}

		public void Add(Country country)
		{
			_context.Countries.Add(country);
			_context.SaveChanges();
		}

		public void AttachRange(List<Country> countries)
		{
			_context.Countries.AttachRange(countries);
		}

		public void ChangeTracking(Country country)
		{
			_context.Entry(country).State = EntityState.Detached;
		}

		public void Delete(Country country)
		{
			var docs = _context.Documents.Where(p => p.CountryId == country.Id).ToList();
			docs.ForEach(p => p.CountryId = null);
			
				
			_context.Countries.Remove(country);
			_context.SaveChanges();
		}

		public List<Country> GetAll()
		{
			return _context.Countries.Include(p => p.DocumentTypes).ToList();
		}

		public Country GetById(int? id)
		{
			return _context.Countries.Include(p => p.DocumentTypes).FirstOrDefault(p=>p.Id==id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
