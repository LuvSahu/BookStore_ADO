using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.AddressModel
{
    public class AddressDataModel
    {
        //[Required]
        [DefaultValue(2)]
        //[Range(1, 3, ErrorMessage = "Choose Address Types As 1 : Home , 2 : Office , 3 : Other")]
        public int AddressType { get; set; }

        [Required]
        //[DefaultValue("")]
        public string FullAddress { get; set; }

        [Required]
        //[DefaultValue("")]
        public string City { get; set; }

        [Required]
        //[DefaultValue("")]
        public string State { get; set; }
    }
}
