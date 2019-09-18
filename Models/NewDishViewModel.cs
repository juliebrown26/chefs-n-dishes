using System.Collections.Generic;
using System;

namespace chefsndishes.Models
{
    public class NewDishViewModel
    {
        public List<Chef> Chefs { get; set; }
        public Dish NewDish { get; set; }
    }
}