﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Demo
{
    //this inform to CLR that class can be serialized-->allow class serialized
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; } 
    }
}
