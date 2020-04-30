﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.BL.DTOs
{
    public class UserDTO
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string DrivingLicense { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ProfilePicturePath { get; set; }

        public bool EmaiConfirmed { get; set; }

    }
}