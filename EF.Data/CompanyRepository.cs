using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF.Core;


namespace EF.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MessageBoardContext _context;

        public CompanyRepository(MessageBoardContext context)
        {
            _context = context;
        }

        public bool Save(Company Entity)
        {
            _context.Companies.Add(Entity);
          
            return true;
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies;
        }

        public Company GetById(int Id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == Id);
        }

    }
}