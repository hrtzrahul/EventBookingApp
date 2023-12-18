using BookEventApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.IRepository
{
    public interface ICommentRepository
    {
        Task<int> PostComment(Comment response);

        Task<IList<Comment>> GetComments();

        Task<Comment> ViewComment(int commentId);

        int EditComment(Comment response);


    }
}
