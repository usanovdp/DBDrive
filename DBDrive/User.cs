using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBDrive
{
    public partial class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long Age { get; set; }
    }
}
