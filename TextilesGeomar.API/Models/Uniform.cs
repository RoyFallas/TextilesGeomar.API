using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class Uniform
{
    public int UniformId { get; set; }

    public int? InstitutionId { get; set; }

    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Status Status { get; set; } = null!;
}
