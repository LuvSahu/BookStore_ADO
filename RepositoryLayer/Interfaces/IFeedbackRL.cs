using CommonLayer.FeedbackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IFeedbackRL
    {
        public bool AddFeedback(int UserId, FeedbackDataModel postModel);
        public List<GetFeedbackModel> GetAllFeedbacksByBookId(int BookId);
        public bool DeleteFeedbackById(int FeedbackId);
    }
}
