using Shop_API_Kurlushuk.Data.Models;
using System.Collections.Generic;

namespace Shop_API_Kurlushuk.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categories> Categories { get; set; }

        public int SelectCategory = 0;
    }
}
