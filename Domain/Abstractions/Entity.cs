﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public abstract class ΤEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
