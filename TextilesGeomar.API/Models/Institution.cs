﻿using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class Institution
{
    public int InstitutionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Uniform> Uniforms { get; set; } = new List<Uniform>();
}
