using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;

namespace MusStore.Data
{
    public class TopicRepository :ITopicRepository
    {
        private readonly MessageBoardContext _dbContext;

        public TopicRepository(MessageBoardContext ctx)
        {
            _dbContext = ctx;
        }

        public bool Save(Topic Entity)
        {
         
            _dbContext.Topics.Add(Entity);
           
            return true;
        }

        public IQueryable<Topic> GetAll()
        {
            return _dbContext.Topics.ToList().AsQueryable();
        }

        public Topic GetById(int Id)
        {
            return _dbContext.Topics.FirstOrDefault(t => t.Id == Id);
        }

        public IQueryable<Topic> FindAll()
        {
            return _dbContext.Topics;
        }
    }
}