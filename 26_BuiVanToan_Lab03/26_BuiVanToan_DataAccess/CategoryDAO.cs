using _26_BuiVanToan_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace _26_BuiVanToan_DataAccess
{

    public class CategoryDAO
    {

        public static List<Category> GetCategories() {
            var listCategories = new List<Category>();
            try
            {
                using (var context = new ApplicationDBContext())
                {

                    listCategories = context.Categories.ToList();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategories;

        }
        public static Category? GetCategoryById(int id)
        {
            using var context = new ApplicationDBContext();
            return context.Categories.SingleOrDefault(c => c.CategoryId == id);
        }
    }
}
