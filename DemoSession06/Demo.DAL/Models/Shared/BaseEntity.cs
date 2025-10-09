using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //User Id
        public DateTime CreatedON { get; set; } //Insertion Date

        public int LastModifiedBy {get; set; } //User ID

        public DateTime LastModifiedOn { get; set; } //Update date

        public bool IsDeleted { get; set; } // To Apply Soft  Delete

    }
}
