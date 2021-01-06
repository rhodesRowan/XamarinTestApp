﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Pages.HomePage
{
    public class HomeMenuItem
    {
        public HomeMenuItem()
        {
            TargetType = typeof(HomeDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
