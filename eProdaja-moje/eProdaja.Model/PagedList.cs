using System.Collections.Generic;

namespace eProdaja.Model
{
    public class PagedList <T>
    {
        public int? Count { get; set; }
        public IList <T> Lista { get; set; }
    }
}