using MusStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MusStore.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;
        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Topic> Get(bool IncludeReplies=false)
        {

            IQueryable<Topic> result;
            if (IncludeReplies)
            {
                result = _repo.GetTopicsIncludingReplies();
            }
            else
            {
                result = _repo.GetTopics();
            }

            var topics = result.OrderByDescending(t => t.Created).Take(25);

            return topics;

        }
      
        public HttpResponseMessage Post(Topic newTopic)
        {
            if (newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            if (_repo.AddTopic(newTopic) &&
            _repo.Save())
            {

                return Request.CreateResponse(HttpStatusCode.Created, newTopic);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
