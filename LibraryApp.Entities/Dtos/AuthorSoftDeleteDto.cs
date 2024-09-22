using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entities.Dtos
{
    public class AuthorSoftDeleteDto
    {
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
    }
}
