using AEDProject.Entities;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Models;
using AEDProject.Services;
using AEDProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics;
using System.Numerics;

namespace AEDProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDocumentService _documentService;
        private readonly ICountryService _countryService;
        private readonly IDocTypeService _docTypeService;
        private readonly IImageService _imageService;
		private readonly IImageRepo _imageRepo;
		public HomeController(IWebHostEnvironment webHostEnvironment, IDocumentService documentService, ICountryService countryService, IDocTypeService docTypeService, IImageService imageService, IImageRepo imageRepo)
        {
            _countryService = countryService;
            _documentService = documentService;
            _webHostEnvironment = webHostEnvironment;
			_docTypeService = docTypeService;
			_imageService = imageService;
            _imageRepo = imageRepo;
		}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string stringId, IFormFile Image)
        {
            ViewBag.Countries = _countryService.GetAllCountries();
            ViewBag.Filter = stringId != null ? _documentService.Search(stringId) : new List<DocumentAddEditViewModel>();
            return View();
        }
        public IActionResult GetDocTypesByCountryId(int CountryId)
        {
            var data = _docTypeService.GetAllDocTypesByCountryId(CountryId);
            return Json(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult DocTypeDelete(int id)
        {
            _docTypeService.Delete(id);
            return RedirectToAction("DocTypeList");
        }
        public IActionResult DocTypeList()
        {
            ViewBag.AllDocTypes = _docTypeService.GetAllTypes();
            return View();
        }
        [HttpPost]
        public IActionResult DocTypeAdd(DocTypeViewModel model)
        {
			ViewBag.Countries = _countryService.GetAllCountries();
            
            if(model.CountryIds == null || model.Name == null)
            {
                ViewBag.Message = "Please fill in the missing data";
                return View(model);
            }
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			if (model.Id > 0)
            {
                _docTypeService.Update(model);
            }
            else
            {
                _docTypeService.Add(model);
            }
            return RedirectToAction("DocTypeList");
        }
        [HttpGet]
        public IActionResult DocTypeAdd(int? Id)
        {
            ViewBag.Countries = _countryService.GetAllCountries();
            DocTypeViewModel model = Id.HasValue ? _docTypeService.GetById(Id.Value) : new DocTypeViewModel();
            return View(model);
        }
		//private void GetCountryDropdownData()
		//{
		//	ViewBag.Countries = _countryService.GetAllCountries();
		//}
		public IActionResult CountryDelete(int id)
        {
            _countryService.Delete(id);
            return RedirectToAction("CountryList");
        }
        public IActionResult CountryList()
        {
            ViewBag.AllCountries = _countryService.GetAllCountries();
            return View();
        }
        [HttpGet]
        public IActionResult CountryAdd(int? Id)
        {
            ViewBag.DocTypes = _docTypeService.GetAllTypes();
            CountryViewModel model = Id.HasValue ? _countryService.GetById(Id.Value) : new CountryViewModel();
            return View(model);
        }
		[HttpPost]
		public IActionResult CountryAdd(CountryViewModel model)
		{
            ViewBag.DocTypes = _docTypeService.GetAllTypes();
            ViewBag.ErrorMessage = "Please fill in the missing data";
            if (model.Name == null || model.DocTypeIds == null)
            {
                return View(model);
            }
            if (!ModelState.IsValid)
			{
				//GetDocTypeDropdownData();
				ViewBag.DocTypes = _docTypeService.GetAllTypes();
				return View(model);
			}
			if (model.Id > 0)
            {
                _countryService.Update(model);
            }
            else
            {
                _countryService.Add(model);
            }
            return RedirectToAction("CountryList");
		}
		//private void GetDocTypeDropdownData()
		//{
		//	ViewBag.Categories = _docTypeService.GetAllTypes();
		//}

		[HttpGet]
        public IActionResult DocumentAdd(int? Id)
        {
			ViewBag.DocTypess = _docTypeService.GetAllTypes();
			ViewBag.Countries = _countryService.GetAllCountries();
            DocumentAddEditViewModel model = Id.HasValue ? _documentService.GetById(Id.Value) : new DocumentAddEditViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult DocumentAdd(DocumentAddEditViewModel model, ICollection<IFormFile> Files)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            var savepath = "";
            var c = allDrives[0];
            {
                if (c.AvailableFreeSpace > 7000000000)
                {
					savepath = @"C:\Users\Admin\Desktop\ImageSave\";
                }
                else
                {
					savepath = @"D:\\Images\";
                }
            }

			ViewBag.Countries = _countryService.GetAllCountries();
			ViewBag.DocTypess = _docTypeService.GetAllTypes();
			ViewBag.ErrorMessage = "Please fill in the missing data";
			if (model.CountryId == null || model.CountryId == null || (model.strId == null))
            {
                return View(model);
            }

            var ifexists = _documentService.CheckstrId(model);
            ViewBag.Countries = _countryService.GetAllCountries();
			ViewBag.DocTypess = _docTypeService.GetAllTypes();
			ViewBag.Message = "Document with this ID already exists";
			if (ifexists == true)
            {
				return View(model);
            }
			if (model.Id > 0)
            {
                _documentService.Update(model);
            }
            else
            {
               model.Id = _documentService.Add(model);
            }
			if (Files != null)
			{
				foreach (var item in Files)
				{
					string filename = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(item.FileName);
					Image type = new Image
					{
						ImageName = savepath + filename,
						DocumentId = model.Id,
					};
					_imageRepo.Add(type);
					_imageRepo.SaveChanges();
					using (var fileStream = new FileStream(savepath + $"{filename}", FileMode.Create))
					{
						item.CopyTo(fileStream);

					}
				}
			}
			return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DocumentDelete(int id)
        {
         
            var data = _documentService.GetById(id);
            _documentService.DeleteImageByDocumentId(data);  
            _documentService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ImageById(int id)
        {
            var data = _imageService.GetByImageId(id);
            var file = System.IO.File.ReadAllBytes(data.ImageName);
            return File(file,"image/jpeg");
        }
    }
}