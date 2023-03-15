using System;
using System.ComponentModel.DataAnnotations;

namespace BlackBulkInsertCodeApp.Models
{
    public partial class Names
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UniqueID { get; set; }
    }
}