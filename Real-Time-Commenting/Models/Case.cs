using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models
{
    public class Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int CaseID { get; set; }        
        public string ProductName { get; set; }
        public string Subject { get; set; }

       
        public int PriorityID { get; set; }
        public int StatusID { get; set; }

        public Nullable<DateTime> DateCreated { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Priotrity Priority { get; set; }
        public virtual Status Status { get; set; }

    }

    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }

    public class Priotrity
    {
        [Key]
        public int PriorityID { get; set; }

        public string PriorityName { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
    }

}