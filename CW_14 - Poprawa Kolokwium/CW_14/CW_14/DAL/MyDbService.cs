using CW_14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.DAL
{
    public class MyDbService : IDBService
    {
        private readonly MyDbContext _context = new MyDbContext();
        public FireTruck getFireTruckById(int id)
        {
            var temp = _context.FireTrucks.Where(x => x.IdFireTruck == id).Include(x => x.FireTruck_Actions).ThenInclude(x =>x.Action).FirstOrDefault();
            return temp;
        }

        public int UpdateEndDateOfAction(int id, DateTime endDate)
        {
            var temp = _context.Actions.Where(x => x.IdAction == id).FirstOrDefault();
            if(temp.EndDate is not null)
            {
                return 1;
            }
            if (temp.StartDate >= endDate)
            {
                return 2;
            }
            temp.EndDate = endDate;
            _context.Actions.Update(temp);
            return 3;
        }
    }
}
