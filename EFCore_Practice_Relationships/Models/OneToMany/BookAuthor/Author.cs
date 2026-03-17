using EFCore_Practice_Relationships.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Relationships.Models.OneToMany.BookAuthor
{
    internal class Author : Entity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
