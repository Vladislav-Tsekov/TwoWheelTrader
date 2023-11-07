using System;
using System.Collections.Generic;

namespace VehEvalu8.Data.DBModels;

public partial class Year
{
    public int Id { get; set; }

    public int Year1 { get; set; }

    public virtual ICollection<Motocross> Motocrosses { get; set; } = new List<Motocross>();

    public virtual ICollection<Enduro> Enduroes { get; set; } = new List<Enduro>();
}
