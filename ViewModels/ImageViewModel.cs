using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int DocumentId { get; set; }
    }
}
