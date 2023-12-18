using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Entities.Base
{
   public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
