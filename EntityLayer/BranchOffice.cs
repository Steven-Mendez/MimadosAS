﻿using System.Collections.Generic;

namespace EntityLayer
{
    public class BranchOffice
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Municipality Municipality { get; set; }

        public List<BranchOfficePhone> Phones { get; set; }

        public bool Active { get; set; }
    }
}
