﻿using System;
using System.Collections.Generic;

namespace MVC_Bootcamp_Assignment_I.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
