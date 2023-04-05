using System;
using System.Collections.Generic;

namespace eProdaja.DataBase;

public partial class JediniceMjere
{
    public int JedinicaMjereId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Proizvodi> Proizvodis { get; } = new List<Proizvodi>();
}
