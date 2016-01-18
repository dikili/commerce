using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core;

namespace EF.Data
{
    public interface ITopicRepository : IRepository<Topic>
    {
        Topic GetTopicByImageId(Guid imgId);
    }
}
