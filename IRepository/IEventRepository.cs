using BookEventApp.Entities;
using BookEventApp.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IList<Event>> GetEvents();
        Task<Event> ViewDetails(int eventId);

        Task<int> CreateEvent(Event eventViewModel, string organiser);

        int UpdateEvent(Event eventViewModel);

        Task<IList<Event>> MyEvents(string organiser);
        Task<IList<Comment>> GetAllCommentByEventId(int eventId);
    }
}
