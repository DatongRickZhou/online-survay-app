﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace week2
{
    public class Product
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }


    }
}