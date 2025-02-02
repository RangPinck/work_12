namespace tour_api.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountOfStars { get; set; }

    public string CountryCode { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
