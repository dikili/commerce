using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusStore.Data
{
    public interface IMessageBoardRepository
    {
        IQueryable<Topic> GetTopics();
        Topic GetTopic(int? Id);
        IQueryable<Topic> GetTopicsIncludingReplies();
        IQueryable<Reply> GetRepliesByTopic(int topicId);
        IQueryable<Company> GetCompanies();
        Company GetCompany(int? Id);

        bool Save();

        bool AddTopic(Topic newTopic);

        bool AddCompany(Company newCompany);

        bool AddReply(Reply newReply);
    }
}
