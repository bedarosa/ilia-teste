
using Domain;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        void Add(Product produto);

        void Update(Product produto);

        void Delete(int id);
    }
}
