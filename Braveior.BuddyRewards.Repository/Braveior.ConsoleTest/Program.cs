using Braveior.BuddyRewards.DTO;
using Braveior.BuddyRewards.Services;
using MongoDB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Braveior.ConsoleTest
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await DB.InitAsync("buddyrewards", "localhost", 27017);
            DataService service = new DataService();



            //await service.CreateTeam(new TeamDTO());
            //var newMember = new MemberDTO { Name = "LamiSree", Email = "lami@outlook.com", Password="password", Role = "Manager" };
            //await service.CreateMember(newMember);
            //await service.AddMembertoTeam(new MemberDTO());

            //var myJsonString = File.ReadAllText("data.json");
            //var members = JsonConvert.DeserializeObject<List<MemberDTO>>(myJsonString);
            //foreach(var member in members)
            //{
            //    member.Role = "Developer";
            //    member.Password = "password";
            //    await service.CreateMember(member);
            //}

            List<string> comments = new List<string>
            {
                "Rajesh is a very good team player and his achievements are remarkable",
                "He is absolutely fantastic to work with and helpful in all aspects",
                "Rajesh' work quality is very high and there were very minimal bugs in his code",
                "Rajesh helped his team members during tough deadlines",
                "He is a wonderful asset to the team",
                "Rajesh helped me during my assignments.Sometimes he gets angry which he can improve",
                "Rajesh is brilliant with his technical abilities. I absolutely like working with him",
                "He is a very good team player , Need to improve on his emotions"
            };


        }

    }
   

}
