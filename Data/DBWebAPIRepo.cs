using CS335_A1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Data
{
    public class DBWebAPIRepo: IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;
        public DBWebAPIRepo(WebAPIDBContext dbContext) { 
            _dbContext = dbContext; 
        }

        public Staff AddStaff(Staff staff)
        {
            EntityEntry<Staff> e = _dbContext.staff.Add(staff);
            Staff c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            IEnumerable<Staff> s = _dbContext.staff.ToList<Staff>();
            return s;
        }

        public IEnumerable<Products> GetItems()
        {
            IEnumerable<Products> s = _dbContext.products.ToList<Products>();
            return s;
        }
        public IEnumerable<Products> GetItemsByName(string name)
        {
            IEnumerable<Products> s = _dbContext.products.ToList<Products>();
            var prod = (from p in s
                        where p.Name.ToLower().Contains(name.ToLower())
                        select p).ToList().OrderBy(a => a.Id).ToList();
            return prod;
        }


        public Staff GetStaffByID(int id)
        {
            Staff s = _dbContext.staff.FirstOrDefault(e => e.Id == id);
            return s;
        }
        public Comments AddComments(Comments comment)
        {
            EntityEntry<Comments> e = _dbContext.comments.Add(comment);
            Comments c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

    }
}
