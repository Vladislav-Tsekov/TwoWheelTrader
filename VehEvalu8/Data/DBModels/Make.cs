namespace VehEvalu8.Data.DBModels;

public partial class Make
{
    public int Id { get; set; }

    public string MakeName { get; set; } = null!;

    public virtual ICollection<Motocross> Motocrosses { get; set; } = new List<Motocross>();

    public virtual ICollection<Enduro> Enduroes { get; set; } = new List<Enduro>();
}
