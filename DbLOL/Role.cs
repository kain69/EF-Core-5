﻿using System.Collections.Generic;

namespace DbLOL
{
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Champion> Champions { get; set; } = new List<Champion>();
    }
}
