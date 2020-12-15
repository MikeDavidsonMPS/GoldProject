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

        //UPDATE = = advised to leave out update for the this project
        //public bool UpdateExistData();

          //Delete
        public bool RemoveDataFromDir(string mealName)
        {
            CafeLibary data = GetDataWithMealName(mealName);  

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

          //Helper Method --- Problem
        public CafeLibary GetDataWithMealName(string mealName)
        {
            foreach(CafeLibary date in _cafeDir)
            {
                if (date.MealName.ToLower() == mealName.ToLower())
                {
                    return date;
                }
            }

            return null;
        }

    }
}

