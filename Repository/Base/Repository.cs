using BookEventApp.Data;
using BookEventApp.Entities.Base;
using BookEventApp.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly EventContext _eventContext;


        public Repository(EventContext eventContext)
        {
            this._eventContext = eventContext ?? throw new ArgumentNullException(nameof(eventContext)); ;
        }

       
    }
}
