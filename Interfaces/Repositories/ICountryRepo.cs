using AEDProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace AEDProject.Interfaces.Repositories
{
    public interface ICountryRepo
    {
        public void Add(Country country);
        public void ChangeTracking(Country country);
		public void AttachRange(List<Country> countries);
		public Country GetById(int? id);
        public List<Country> GetAll();
        public void Delete(Country country);
        public void SaveChanges();
    }
}
