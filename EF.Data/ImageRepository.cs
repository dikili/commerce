
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class ImageRepository :IImageRepository
    {
        private MessageBoardContext _dbContext;

        public ImageRepository(MessageBoardContext ctx)
        {
            _dbContext = ctx;
        }

        public bool Save(Core.Image Entity)
        {
            try
            {
                _dbContext.Images.Add(Entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<Core.Image> GetAll()
        {
            return _dbContext.Images.ToList().AsQueryable();
        }

        public Core.Image GetById(int Id)
        {
            return _dbContext.Images.Where(p => p.TopicId == Id).FirstOrDefault();
        }

        public IEnumerable<string> GetAllImagesByTopic(int topicId)
        {
            return from a in _dbContext.Images
                   where a.TopicId == topicId
                   select a.ImagePath;

            //below does not work somehow but above is fine by compiler interestingly
            //return _dbContext.Images.Where(p => p.TopicId == topicId).SelectMany(p => p.ImagePath);
        }
    }
}
