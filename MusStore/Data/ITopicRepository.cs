using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusStore.Data
{
    public interface ITopicRepository : IRepository<Topic>
    {
        IQueryable<Topic> FindAll();
    }
}
