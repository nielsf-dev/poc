﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Roletype
    {
        public int Id { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public int Raamwerkid { get; set; }
    }
}
