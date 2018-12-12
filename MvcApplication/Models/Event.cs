using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Technology { get; set; }
        public string StartingDate { get; set; }
        public string RegistrationLink { get; set; }
    }
}