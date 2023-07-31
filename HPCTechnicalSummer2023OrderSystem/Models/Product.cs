﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPCTechnicalSummer2023OrderSystem.Models;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
}
