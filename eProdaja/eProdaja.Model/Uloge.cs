﻿using System;
using System.Collections.Generic;

namespace eProdaja.Model
{
    
    public partial class Uloge
    {
        public int UlogaId { get; set; }

        public string Naziv { get; set; } = null!;

        public string? Opis { get; set; }
    }

}
