using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication.DAL
{
    public class EventInitializer: DropCreateDatabaseIfModelChanges<EventContext>
    {
        protected override void Seed(EventContext context)
        {
                var eventList = new List<Event>();
                for (var i = 1; i <= 50000; i++)
                {
                    var e = new Event
                    {
                        RegistrationLink = string.Format("http://www.registration{0}.com",i.ToString()),
                        Technology = ".NET",
                        StartingDate = DateTime.Now.ToString(),
                        Title = (i + 4).ToString() + " .NET Event" + i.ToString()
                    };
                    eventList.Add(e);
                }

            //context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            eventList.ForEach(x => context.Events.Add(x));
            context.SaveChanges();        
        }
    }
}