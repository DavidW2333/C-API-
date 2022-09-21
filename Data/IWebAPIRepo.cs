using CS335_A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Data
{
    public interface IWebAPIRepo
    {
        IEnumerable<Staff> GetAllStaff(); 
        Staff GetStaffByID(int id);
        Staff AddStaff(Staff staff);
        IEnumerable<Products> GetItems();
        IEnumerable<Products> GetItemsByName(string name);
        Comments AddComments(Comments comment);
    }
}
