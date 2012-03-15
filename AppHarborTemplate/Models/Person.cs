using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppHarborTemplate.Models
{
    public class Couple
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Parters { get; set; }
    }
    
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Couple Couple { get; set; }
        public virtual ICollection<Deed> Deeds { get; set; }
    }

    public class Deed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Act> Acts { get; set; }
    }

    public class Act
    {
        public Act()
        {
            DateClaimed = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateClaimed { get; private set; }
        public int DeedId { get; set; }
        public virtual Deed Deed { get; set; }

    }

    

}