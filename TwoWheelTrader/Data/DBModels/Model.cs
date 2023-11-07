using System;
using System.Collections.Generic;

namespace VehEvalu8.Data.DBModels;

public partial class Model
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public virtual ICollection<Motocross> Motocrosses { get; set; } = new List<Motocross>();

    public virtual ICollection<Enduro> Enduroes { get; set; } = new List<Enduro>();
}
