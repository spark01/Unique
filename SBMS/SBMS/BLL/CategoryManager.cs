using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SBMS.Model;
using SBMS.Repository;


namespace SBMS.BLL
{
    class CategoryManager
    {
       
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public DataTable Display()
        {
            return _categoryRepository.Display();
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public bool IsNameExist(Category category)
        {
            return _categoryRepository.IsNameExist(category);
        }

        public bool IsCodeExist(Category category)
        {
            return _categoryRepository.IsCodeExist(category);
        }
        public List<Category> loadCombo()
        {
            return _categoryRepository.loadCombo();
        }
    }
}
