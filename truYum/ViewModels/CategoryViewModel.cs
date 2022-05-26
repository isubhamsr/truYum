using truYum.Models;
namespace truYum.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Category { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
