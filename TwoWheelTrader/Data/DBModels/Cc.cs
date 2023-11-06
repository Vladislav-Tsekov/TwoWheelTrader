using System;
using System.Collections.Generic;

namespace VehEvalu8.Data.DBModels;

public partial class Cc
{
    public int Id { get; set; }

    public int EngineSize { get; set; }

    public virtual ICollection<Motocross> Motocrosses { get; set; } = new List<Motocross>();
}
