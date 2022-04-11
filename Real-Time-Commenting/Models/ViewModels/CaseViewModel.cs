using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models.ViewModels
{
    public class CaseViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Case Number")]
        public int CaseID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Priority")]
        public int PriorityID { get; set; }

        [Display(Name = "Status")]
        public int StatusID { get; set; }

        public Nullable<DateTime> DateCreated { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Priotrity Priotrity { get; set; }
        public virtual Status Status { get; set; }
    }
}