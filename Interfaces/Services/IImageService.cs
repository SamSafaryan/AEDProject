using AEDProject.ViewModels;

namespace AEDProject.Interfaces.Services
{
	public interface IImageService
	{
		public List<ImageViewModel> GetAllTypes();
		public void Delete(int id);
		public void Update(ImageViewModel model);
		public ImageViewModel GetById(int Id);
        public List<ImageViewModel> GetAllById(int Id);
		public ImageViewModel GetByImageId(int id);
    }
}
