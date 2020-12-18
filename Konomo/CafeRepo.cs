using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomCafeClassLibary
{
        
    public class CafeRepo
    {
        private readonly List<CafeLibary> _cafeDir = new List<CafeLibary>();

           //CRUD  (no "Update" to CRUD is needed)

           //Create
        public void AddDatatoMenu(CafeLibary data)
        {
            _cafeDir.Add(data);
        }

           //Read
        public List<CafeLibary> GetCafeLibaries()
        {
            return _cafeDir;
        }

          //Update N/A

          //Delete
        public bool RemoveDataFromDir(int mealNumber)
        {
            CafeLibary data = GetDataWithMealNumber(mealNumber);  

            if (data == null)
            {
                return false;
            }

            int firstCount = _cafeDir.Count;
            _cafeDir.Remove(data);

            if (firstCount > _cafeDir.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

          //Helper Method
        public CafeLibary GetDataWithMealNumber(int mealNumber)
        {
            foreach (CafeLibary date in _cafeDir)
            {
                if (date.MealNumber == mealNumber)
                {
                    return date;
                }
            }

            return null;
        }

    }
}

