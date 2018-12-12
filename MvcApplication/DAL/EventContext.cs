using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication.DAL
{
    public class EventContext: DbContext
    {
        public EventContext()
            : base("EventContext")
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}