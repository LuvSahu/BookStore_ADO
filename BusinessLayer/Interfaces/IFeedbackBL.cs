using CommonLayer.FeedbackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IFeedbackBL
    {
        public bool AddFeedback(int UserId, FeedbackDataModel postModel);
        public List<GetFeedbackModel> GetAllFeedbacksByBookId(int BookId);
        public bool DeleteFeedbackById(int FeedbackId);
    }
}
