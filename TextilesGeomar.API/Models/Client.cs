﻿using System;
using System.Collections.Generic;

namespace TextilesGeomar.API.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public int? InstitutionId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual Institution? Institution { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
