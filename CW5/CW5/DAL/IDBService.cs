using CW5.Model;
using CW5.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW5.DAL
{
    public interface IDBService {

    public int AddProducts(OrderRequest request);
    public IEnumerable<Warehouse> getAllWarehouses();
    public IEnumerable<Product> GetAllProducts();
    public int AddWithProcedure(OrderRequest request);

    }
}
