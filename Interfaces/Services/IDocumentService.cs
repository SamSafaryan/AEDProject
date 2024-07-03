using AEDProject.ViewModels;

namespace AEDProject.Interfaces.Services
{
    public interface IDocumentService
    {
        public List<DocumentAddEditViewModel> GetAllDocuments();
        public int Add(DocumentAddEditViewModel model);
        public bool CheckstrId(DocumentAddEditViewModel model);
        public void DeleteImageByDocumentId(DocumentAddEditViewModel model);
		public void Delete(int id);
        public List<DocumentAddEditViewModel> Search(string? stringId);
        public void Update(DocumentAddEditViewModel model);
        public DocumentAddEditViewModel GetById(int Id);
    }
}
