using CW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Services
{
    public interface IDBService
    {
        IEnumerable<Animal> GetAnimals(string orderBy);
        int AddAnimal(Animal animal);
        int UpdateAnimal(Animal animal, int Id);
        int DeleteAnimal(int Id);
    }
}
