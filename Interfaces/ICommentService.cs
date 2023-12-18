using BookEventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Interfaces
{
    public interface ICommentService
    {
        Task<int> PostComment(CommentModel response);

        Task<IList<CommentModel>> GetComments();

        Task<CommentModel> ViewComment(int commentId);

        int EditComment(CommentModel response);

    }
}
