using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Guestbook.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PostText { get; set; }
        public DateTime PostDate { get; set; }
    }
}