using CW7.DTO.Responses;
using CW7.Models;
using CW7.Requests;
using CW7.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CW7.Services
{
    public class DbService : IDbService
    {
        private readonly s18986Context _context;
        public DbService()
        {
            _context = new s18986Context();
        }

        public int AddClientToTrip(AddClientToTripRequest request, int idTrip)
        {
            int clientId = 0;
            //Czy w bazie danych istnieje klient o podanym id
            HandleClient(clientId, request);
                     
            // czy dany klient ma już przypisaną wycieczke o podanym id?
            if (_context.ClientTrips.
                Where(ct => ct.IdClient == clientId && ct.IdTrip == idTrip)
                .Any())
            {
                return 1; // Potem parsowane na podniesienie wyjątku
            }

            // czy istnieje wycieczka o podanym id?
            if (_context.Trips.
                Where(x => x.IdTrip == idTrip)
                .Count()==0)
            {
                return 2; // Potem parsowane na podniesienie wyjątku
            }

            AddClientTrip(request, clientId, idTrip);
            return 0;
        }
        private void AddClientTrip(AddClientToTripRequest request, int clientId, int idTrip)
        {
            string toSplit = request.PaymentDate;
            string[] dateElements = toSplit.Split('/');
            var clientTrip = new ClientTrip
            {
                IdClient = clientId,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = new DateTime(int.Parse(dateElements[2]), int.Parse(dateElements[0]), int.Parse(dateElements[1]))
            };
            _context.ClientTrips.Add(clientTrip);
            _context.SaveChanges();
        }
        private void HandleClient(int clientId, AddClientToTripRequest request)
        {
            if (_context.Clients.Where(x => x.Pesel.Equals(request.Pesel)).Count() != 0)
            {

                //Wczytanie Id
                clientId = _context.Clients
                    .Where(c => c.Pesel == request.Pesel)
                    .Select(c => c.IdClient)
                    .Single();
            }
            else
            {
                clientId = _context.Clients.Max(x => x.IdClient) + 1;
                _context.Clients.Add(new Client
                {
                    IdClient = clientId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Telephone = request.Telephone,
                    Pesel = request.Pesel
                });
            }
        }

        public int DeleteClient(int idClient)
        {
            int temp = _context.ClientTrips.Where(x => x.IdClient == idClient).Count();
            if (temp > 0)
            {
                return 1;
            }
            else
            {
                _context.Clients.Remove(_context.Clients.Where(x => x.IdClient == idClient).FirstOrDefault());
                _context.SaveChanges();
                return 0;
            }
        }

        public IEnumerable<TripResponse> GetSortedTrips()
        {
            //Pobranie całości danych z bazy
            var temp = _context.Trips
               .Include(x => x.CountryTrips)
               .ThenInclude(x => x.IdCountryNavigation)
               .Include(y => y.ClientTrips)
               .ThenInclude(y => y.IdClientNavigation)
               .OrderByDescending(y => y.DateFrom)
               .ToList();
            //Przypisanie danych do odpowiedniego formatu
            var result = new List<TripResponse>();
            foreach (var a in temp)
            {
                result.Add(new TripResponse
                {
                    IdTrip = a.IdTrip,
                    Name = a.Name,
                    Description = a.Description,
                    DateFrom = a.DateFrom,
                    DateTo = a.DateTo,
                    MaxPeople = a.MaxPeople,
                    Countries = a.CountryTrips.Select(x => new CountryResponse
                    {
                        Name = x.IdCountryNavigation.Name
                    }).ToList(),
                    Clients = a.ClientTrips.Select(x => new ClientResponse
                    {
                        FirstName = x.IdClientNavigation.FirstName,
                        LastName = x.IdClientNavigation.LastName
                    }).ToList()

                });
            }
            return result;
        }
    }
}
