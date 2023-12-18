using BookEventApp.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.IRepository.Base
{
    public interface IRepository<T> where T : Entity
    {
    }
}
