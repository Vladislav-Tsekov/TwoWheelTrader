using System;
using System.Collections.Generic;

namespace VehEvalu8.Data.DBModels;

public partial class Enduro
{
    public int Id { get; set; }

    public int? MakeId { get; set; }

    public int? ModelId { get; set; }

    public int? Ccid { get; set; }

    public int? YearId { get; set; }

    public decimal? PriceForeign { get; set; }

    public decimal? PriceBgn { get; set; }

    public int? Distance { get; set; }

    public decimal? FuelCost { get; set; }

    public decimal? TotalCost { get; set; }

    public decimal? Profit { get; set; }

    public decimal? Roi { get; set; }

    public string? Link { get; set; }

    public virtual Cc? Cc { get; set; }

    public virtual Make? Make { get; set; }

    public virtual Model? Model { get; set; }

    public virtual Year? Year { get; set; }
}
