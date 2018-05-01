using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityAssist2018.Models;

namespace CommunityAssist2018.Models
{
    public class NewPerson
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public string password { get; set; }
        public string ApartmentNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }


    }
}