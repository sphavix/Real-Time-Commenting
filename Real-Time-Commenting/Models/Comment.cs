using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Real_Time_Commenting.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int CaseID { get; set; }
    }
}