using CW_14.DTO.Responses;
using CW_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_14.DAL
{
    public interface IDBService
    {
        public TruckResponse getFireTruckById(int id);
        public int UpdateEndDateOfAction(int id, DateTime endDate);
        public void AddNewAction(Models.Action action);
    }
}
