﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusStore.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        private MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext ctx)
        {
            this._ctx = ctx;
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {

            return _ctx.Topics.Include("Replies");
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(r => r.TopicId == topicId);
        }


        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO logging
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _ctx.Topics.Add(newTopic);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Topic> GetTopics()
        {
            // var ctx=new MessageBoardContext(); this is expensive and this needs to be disposed properly as well.
            return _ctx.Topics;
        }


        public bool AddReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}