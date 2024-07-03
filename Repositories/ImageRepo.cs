using AEDProject.Entities.Data;
using AEDProject.Entities;
using AEDProject.Interfaces.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace AEDProject.Repositories
{
	public class ImageRepo : IImageRepo
	{
		private readonly AEDContext _context;
		public ImageRepo(AEDContext context)
		{
			_context = context;
		}

		public void Add(Entities.Image image)
		{
			_context.Images.Add(image);
			_context.SaveChanges();
		}

		public void Delete(Entities.Image image)
		{
			_context.Images.Remove(image);
			_context.SaveChanges();
		}

		public List<Entities.Image> GetAll()
		{
			return _context.Images.ToList();
		}

		public Entities.Image GetById(int id)
		{
			return _context.Images.Find(id);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
