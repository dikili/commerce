using System.Linq;
using MusStore.Data;
using MusStore.Models;

namespace MusStore.Controllers
{
    public interface ICompanyRepository :IRepository<Company>
    {
        //IQueryable<Company> FindAll();

    }
}