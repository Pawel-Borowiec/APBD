using CW_14.DTO.Responses;
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



        public void AddNewAction(Models.Action action)
        {
            _context.Actions.Add(action);
        }


        public TruckResponse getFireTruckById(int id)
        {
            TruckResponse response = new TruckResponse();
            response.ActionsResponses = new List<ActionResponse>();
            var Truck = _context.FireTrucks.Where(x => x.IdFireTruck == id).FirstOrDefault();
            response.FireTruck = Truck;
            List<FireTruck_Action> Actions = _context.FireTruck_Actions.Where(x => x.IdFireTruck == id).ToList();
            foreach(FireTruck_Action element in Actions)
            {
                ActionResponse temp = new ActionResponse();
                temp.AssigmentDate = element.AssigmentTime;
                temp.numberOdFirefighters = _context.Firefighter_Actions.Where(x => x.IdAction == element.IdAction).ToList().Count;
                temp.Action = _context.Actions.Where(x => x.IdAction == element.IdAction).FirstOrDefault();
                response.ActionsResponses.Add(temp);
            }
            return response;
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
