using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Braveior.BuddyRewards.Services.Models
{
    /// <summary>
    /// Entity class to store mongodb member documents
    /// </summary>
    public class Member : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

    }
}
