using System.Linq;
using EF.Core;



namespace EF.Data
{
    public interface ICompanyRepository :IRepository<Company>
    {
        //IQueryable<Company> FindAll();

    }
}