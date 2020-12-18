using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomCafeClassLibrary
{
        
    public class CafeRepo
    {
        private readonly List<CafeLibrary> _cafeDir = new List<CafeLibrary>();

           //CRUD  (no "Update" to CRUD is needed)

           //Create
        public void AddDatatoMenu(CafeLibrary data)
        {
            _cafeDir.Add(data);
        }

           //Read
        public List<CafeLibrary> GetCafeLibaries()
        {
            return _cafeDir;
        }

          //Update N/A

          //Delete
        public bool RemoveDataFromDir(int mealNumber)
        {
            CafeLibrary data = GetDataWithMealNumber(mealNumber);  

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
        public CafeLibrary GetDataWithMealNumber(int mealNumber)
        {
            foreach (CafeLibrary date in _cafeDir)
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

