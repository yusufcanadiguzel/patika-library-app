using LibraryApp.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Genre { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public int CopiesAvailable { get; set; }
    }
}
