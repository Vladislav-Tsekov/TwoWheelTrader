using System;
using System.Collections.Generic;

namespace VehEvalu8.Data.DBModels;

public partial class Make
{
    public int Id { get; set; }

    public string MakeName { get; set; } = null!;

    public virtual ICollection<Motocross> Motocrosses { get; set; } = new List<Motocross>();
}
