using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syinergy_RP.API.Classes
{
    public class UserClass
    {
        public string userid {  get; set; }
        public int Adrenaline { get; set; }
        public int Painkillers { get; set; }
        public static List<UserClass> List = new List<UserClass>();
        public UserClass(string userid) 
        {
            this.userid = userid;
            this.Adrenaline = 0;
            this.Painkillers = 0;
            List.Add(this);
        }
        public static UserClass Get(string userid)
        {
            return List.Where(x=>x.userid == userid).FirstOrDefault();
        }
    }
}
