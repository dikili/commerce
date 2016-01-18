using System;


namespace EF.Data
{
    public interface IUnitOfWork
    {
        ITopicRepository Topics { get; }
        ICompanyRepository Companies { get; }
        IImageRepository Images { get; }
        void Commit();
    }
}