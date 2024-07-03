using AEDProject.Entities;
using AEDProject.Entities.Enums;
using AEDProject.Interfaces.Repositories;
using AEDProject.Interfaces.Services;
using AEDProject.Repositories;
using AEDProject.ViewModels;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace AEDProject.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepo _DocumentRepo;
        private readonly ICountryService _countryService;
		private readonly IDocTypeService _doctypeService;
		private readonly IImageService _imageService;
        public DocumentService(IDocumentRepo repo, ICountryService countryService, IImageService imageService, IDocTypeService doctypeService)
        {
            _DocumentRepo = repo;
            _countryService = countryService;
            _imageService = imageService;
            _doctypeService = doctypeService;
        }
        public int Add(DocumentAddEditViewModel model)
        {
            AEDProject.Entities.Document document = new AEDProject.Entities.Document
            {
                ISS = model.ISS,
                CountryId = model.CountryId,
                DocumentTypeId = model.DocumentTypeId,
                AllAngels = model.AllAngels,
                DOB = model.DOB,
                Enable = model.Enable,
                EXP = model.EXP,
                Sex = model.Sex,
                Sides = model.Sides,
                strId = model.strId,
                SSN = model.SSN,
                HaveSelfie = model.HaveSelfie,
            };
			
			_DocumentRepo.Add(document);
            _DocumentRepo.SaveChanges();
            return document.Id;

        }

        public void Delete(int id)
        {
            var entity = _DocumentRepo.GetById(id);
            _DocumentRepo.Delete(entity);

			
		}

        public List<DocumentAddEditViewModel> GetAllDocuments()
        {
            var data = _DocumentRepo.GetAll();
            var documentList = data.Select(d => new DocumentAddEditViewModel
            {
                Id = d.Id,
                ISS = d.ISS,
                AllAngels = d.AllAngels,
                DOB = d.DOB,
                Enable = d.Enable,
                EXP = d.EXP,
                Sex = d.Sex,
                Sides = d.Sides,
                strId = d.strId,
                SSN = d.SSN,
                HaveSelfie = d.HaveSelfie,
                DocTypeName = d.DocumentTypeId.HasValue? _doctypeService.GetById(d.DocumentTypeId)?.Name : null,
                CountryName = d.CountryId.HasValue? _countryService.GetById(d.CountryId)?.Name:null,
                Images = _imageService.GetAllById(d.Id)
            }).ToList();
            return documentList;
        }

        public DocumentAddEditViewModel GetById(int id)
        {
            var document = _DocumentRepo.GetById(id);
            var images = _imageService.GetAllById(id);
            return new DocumentAddEditViewModel
            {
                Id = document.Id,
                ISS = document.ISS,
				CountryId = document.CountryId,
                DocumentTypeId = document.DocumentTypeId,
                AllAngels = document.AllAngels,
                DOB = document.DOB,
                Enable = document.Enable,
                EXP = document.EXP,
                Sex = document.Sex,
                Sides = document.Sides,
                strId = document.strId,
                SSN = document.SSN,
                HaveSelfie = document.HaveSelfie,
                Images = images
            };
        }

        public List<DocumentAddEditViewModel> Search(string? stringId)
        {
            var documents = GetAllDocuments();
            return documents.Where(x => x.strId.ToLower().Contains(stringId.ToLower())).ToList();
		}
        public void Update(DocumentAddEditViewModel model)
        {
            var documentEntity = _DocumentRepo.GetById(model.Id);
            documentEntity.ISS = model.ISS;
            documentEntity.CountryId = model.CountryId;
            documentEntity.DocumentTypeId = model.DocumentTypeId;
            documentEntity.AllAngels = model.AllAngels;
            documentEntity.DOB = model.DOB;
            documentEntity.Enable = model.Enable;
            documentEntity.EXP = model.EXP;
            documentEntity.Sex = model.Sex;
            documentEntity.Sides = model.Sides;
            documentEntity.strId = model.strId;
            documentEntity.SSN = model.SSN;
            documentEntity.HaveSelfie = model.HaveSelfie;
            _DocumentRepo.SaveChanges();


            if(model.ImageIds!= null && model.ImageIds.Any())
            {
                var imageFiles =_imageService.GetAllById(model.Id)
                    .Where(p=> model.ImageIds.Contains(p.Id)).ToList();
                foreach(var image in imageFiles)
                {
                    if(File.Exists(image.ImageName))
                    {
                        File.Delete(image.ImageName);
                        _imageService.Delete(image.Id);
                    }
                }
            }
        }

        public void DeleteImageByDocumentId(DocumentAddEditViewModel model)
        {
			
			
				var imageFiles = _imageService.GetAllById(model.Id)
					.ToList();
				foreach (var image in imageFiles)
				{
					if (File.Exists(image.ImageName))
					{
						File.Delete(image.ImageName);
						_imageService.Delete(image.Id);
					}
				
			    }
		}

		public bool CheckstrId(DocumentAddEditViewModel model)
		{
			bool checkDocumentExists
				= _DocumentRepo.GetAllQuerable()
				.Any(p => p.strId == model.strId && p.Id != model.Id);
            return checkDocumentExists;

        }
	}
}
