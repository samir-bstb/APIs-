using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hmn_API.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hmn_API.Services
{
    //logic
    //By organizing these operations into a service class
    //the code becomes more modular and easier to maintain
    //The service can be used by other parts of the application
    //such as controllers
    public class HumanServices
    {
        static List<Human> humans {get;}
        static int nextId = 1003;

        static HumanServices()
        {
            humans = new List<Human>
            {
                new Human {Id = 1001, Name = "John Krasinsky", Age = 25, Height = 1.81M, Weight = 82.00M, Gender = "Male"},
                new Human {Id = 1002, Name = "Jane Doe", Age = 30, Height = 1.65M, Weight = 67.00M, Gender = "Female"}
            };
        }

        public static List<Human> GetAll() => humans;

        public static Human? Get(int id) => humans.FirstOrDefault(p => p.Id == id);

        public static void Create(Human human)
        {
            human.Id = nextId++;
            humans.Add(human);
        }

        public static void Delete(int id)
        {
            var human = Get(id);
            if(human is null)
                return;

            humans.Remove(human);
        }

        public static void Update(Human human)
        {
            var index = humans.FindIndex(p => p.Id == human.Id);
            if(index == -1)
                return;

            humans[index] = human;
        }
    }
}