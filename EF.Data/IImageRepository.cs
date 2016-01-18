using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core;

namespace EF.Data
{
    public interface IImageRepository : IRepository<Image>
    {
        //In additional to generic repository functions 
        //add another function that will return all the paths 
        //of the pictures that the topic id is given...

        IEnumerable<string> GetAllImagesByTopic(int topicId);


    }
}
