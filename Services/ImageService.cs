using AEDProject.Entities;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Repositories;
using AEDProject.ViewModels;

namespace AEDProject.Services
{
	public class ImageService : IImageService
	{
		private readonly IImageRepo _imageRepo;
		public ImageService(IImageRepo imageRepo)
		{
			_imageRepo = imageRepo;
		}

		public void Delete(int id)
		{
			var entity = _imageRepo.GetById(id);
			_imageRepo.Delete(entity);
		}

        public List<ImageViewModel> GetAllById(int Id)
        {
			var data = _imageRepo.GetAll()
				.Where(d => d.DocumentId == Id);
            var imageList = data.Select(d => new ImageViewModel
            {
                Id = d.Id,
                ImageName = d.ImageName,
                DocumentId = d.DocumentId,
            }).ToList();
            return imageList;
        }

        public List<ImageViewModel> GetAllTypes()
		{
			var data = _imageRepo.GetAll();
			var imageList = data.Select(d => new ImageViewModel
			{
				Id = d.Id,
				ImageName = d.ImageName,
				DocumentId = d.DocumentId,
			}).ToList();
			return imageList;
		}

		public ImageViewModel GetById(int Id)
		{
			var document = _imageRepo.GetById(Id);
			return new ImageViewModel
			{
				Id = document.Id,
				ImageName = document.ImageName,
				DocumentId = document.DocumentId,
			};
		}

		public ImageViewModel GetByImageId(int id)
		{
			var image = _imageRepo.GetById(id);
			return new ImageViewModel
			{
				Id = image.Id,
				ImageName = image.ImageName,
				DocumentId = image.DocumentId,
			};
		}

		public void Update(ImageViewModel model)
		{
			var imageEntity = _imageRepo.GetById(model.Id);
			imageEntity.ImageName = model.ImageName;
			imageEntity.DocumentId = model.DocumentId;
			_imageRepo.SaveChanges();
		}
	}
}
