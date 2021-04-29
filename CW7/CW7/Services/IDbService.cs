using CW7.Models;
using CW7.Requests;
using CW7.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW7.Services
{
    public interface IDbService
    {
        public IEnumerable<TripResponse> GetSortedTrips();
        public int DeleteClient(int idClient);
        public int AddClientToTrip(AddClientToTripRequest request, int idTrip);

    }
}
