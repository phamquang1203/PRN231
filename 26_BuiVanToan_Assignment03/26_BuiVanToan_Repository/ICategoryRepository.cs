using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface ICategoryRepository
    {
        void SaveCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetCategories();
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        List<Product> GetProducts(int categoryId);
    }
}
