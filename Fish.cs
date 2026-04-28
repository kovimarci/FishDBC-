using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishDB
{
    public class Fish
    {
        public int id { get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public int userId { get; set; }
        public override string ToString()
        {
            return $"ID: {id} | {name} {weight} kg  -  user: {userId}";
        }
    }
}
