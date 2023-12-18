using BookEventApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Interfaces
{
    public interface IEventService
    {
        Task<IList<EventModel>> GetEvents();
        Task<EventModel> ViewDetails(int eventId);

        Task<int> CreateEvent(EventModel eventViewModel, string organiser);

        int UpdateEvent(EventModel eventViewModel);

        Task<IList<EventModel>> MyEvents(string organiser);
        Task<IList<CommentModel>> GetAllCommentByEventId(int eventId);
    }
}
