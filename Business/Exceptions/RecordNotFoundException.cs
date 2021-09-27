﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agap2it.labs.projects.PSM.Business.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() : base("The record was not found.")
        {

        }
    }
}
