using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace chefsndishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Calories")]
        [Range(1, 1000000)]
        public int Calories { get; set; }

        [Required]
        [Range(1, 6)]
        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Chef Creator { get; set; }

        [Required(ErrorMessage = "Please choose a chef")]
        public int ChefId { get; set; }
    }
}