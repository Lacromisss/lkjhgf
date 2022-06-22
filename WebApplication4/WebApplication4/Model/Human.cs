using System;

namespace WebApplication4.Model
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
