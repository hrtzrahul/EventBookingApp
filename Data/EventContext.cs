using BookEventApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApp.Data
{
    public class EventContext : IdentityDbContext //BookEventContext is db context class
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Comment> Comment { get; set; }

        

    }

   
    
}
