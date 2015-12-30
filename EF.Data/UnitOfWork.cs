

using System;

namespace EF.Data
{
    public class UnitOfWork :IUnitOfWork
    {

        private readonly MessageBoardContext _context;
        private readonly ICompanyRepository _companies;
        private readonly ITopicRepository _topics;

        public UnitOfWork(MessageBoardContext context,ITopicRepository topics,ICompanyRepository companies)
        {
            _context = context;
            _topics = topics;
            _companies = companies;
        }

        public ITopicRepository Topics
        {
            get { return _topics; }
        }

        public ICompanyRepository Companies
        {
            get { return _companies; }
        }

        public void Commit()
        {
             _context.SaveChanges();
        }

      
    }
}