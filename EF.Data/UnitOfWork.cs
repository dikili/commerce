

using System;

namespace EF.Data
{
    public class UnitOfWork :IUnitOfWork
    {

        private readonly MessageBoardContext _context;
        private readonly ICompanyRepository _companies;
        private readonly ITopicRepository _topics;
        private readonly IImageRepository _images;

        public UnitOfWork(MessageBoardContext context,ITopicRepository topics,ICompanyRepository companies,IImageRepository images)
        {
            _context = context;
            _topics = topics;
            _companies = companies;
            _images = images;
        }

        public ITopicRepository Topics
        {
            get { return _topics; }
        }

        public ICompanyRepository Companies
        {
            get { return _companies; }
        }

        public IImageRepository Images
        {
            get { return _images; }
        }

        public void Commit()
        {
             _context.SaveChanges();
        }

      
    }
}