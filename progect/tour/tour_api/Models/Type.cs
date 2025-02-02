namespace tour_api.Models;

public partial class Type
{
    public int Id { get; set; }

    public string Type1 { get; set; } = null!;

    public virtual ICollection<ToursType> ToursTypes { get; set; } = new List<ToursType>();
}
