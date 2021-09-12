using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreApp1.Core
{
    public class Hero
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required]
        public Type Type { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
    public enum Type
    {
        DC, Marvel, StarWars
    }
}
