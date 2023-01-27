using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.AdminModel
{
    public class AdminLoginModel
    {
        [Required]
        [DefaultValue("")]
        public string AdminEmailID { get; set; }

        [Required]
        [DefaultValue("")]
        public string AdminPassword { get; set; }
    }
}
