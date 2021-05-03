using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Braveior.BuddyRewards.Services.Models
{
    /// <summary>
    /// Entity class to store mongodb Rating documents
    /// </summary>
    public class Rating : Entity
    {
        public string Comment { get; set; }

        public int Star { get; set; }

        //One to One relationship with the Member document
        public One<Member> RatedByRef { get; set; }

        //One to One relationship with the Member document
        public One<Member> RatedForRef { get; set; }

        public string RatedBy { get; set; }

        public string RatedFor { get; set; }

        public DateTime RatingDate { get; set; }

    }
}
