﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Caterory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
