using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Uniform> Uniforms { get; set; } = new List<Uniform>();
}
