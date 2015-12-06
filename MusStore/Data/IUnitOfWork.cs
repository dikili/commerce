using System;
using MusStore.Controllers;

namespace MusStore.Data
{
    public interface IUnitOfWork
    {
        ITopicRepository Topics { get; }
        ICompanyRepository Companies { get; }
        void Commit();
    }
}