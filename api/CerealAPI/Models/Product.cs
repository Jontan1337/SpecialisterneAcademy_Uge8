using System;
using System.Collections.Generic;

namespace CerealAPI.Models;

public partial class Product
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string? Type { get; set; }

    public int? Calories { get; set; }

    public int? Protein { get; set; }

    public int? Fat { get; set; }

    public int? Sodium { get; set; }

    public float? Fiber { get; set; }

    public float? Carbo { get; set; }

    public int? Sugars { get; set; }

    public int? Potass { get; set; }

    public int? Vitamins { get; set; }

    public int? Shelf { get; set; }

    public float? Weight { get; set; }

    public float? Cups { get; set; }

    public float? Rating { get; set; }
}
