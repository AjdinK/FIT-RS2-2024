﻿using System;
using System.Collections.Generic;

namespace eProdaja.DataBase;

public partial class Narudzbe
{
    public int NarudzbaId { get; set; }

    public string BrojNarudzbe { get; set; } = null!;

    public int KupacId { get; set; }

    public DateTime Datum { get; set; }

    public bool Status { get; set; }

    public bool? Otkazano { get; set; }

    public virtual ICollection<Izlazi> Izlazis { get; } = new List<Izlazi>();

    public virtual Kupci Kupac { get; set; } = null!;

    public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; } = new List<NarudzbaStavke>();
}
