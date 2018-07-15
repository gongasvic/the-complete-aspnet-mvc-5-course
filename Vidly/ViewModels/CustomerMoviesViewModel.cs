﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerMoviesViewModel
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }
    }
}