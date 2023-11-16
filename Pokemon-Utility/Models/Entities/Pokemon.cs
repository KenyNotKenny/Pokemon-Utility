using System.Collections.Generic;

namespace Pokemon;

public partial class Pokemon
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? EvolvesFromSpeciesId { get; set; }

    public int? GenderRate { get; set; }

    public int? CaptureRate { get; set; }

    public virtual Pokemon? EvolvesFromSpecies { get; set; }

    public virtual ICollection<Pokemon> InverseEvolvesFromSpecies { get; set; } = new List<Pokemon>();
}
