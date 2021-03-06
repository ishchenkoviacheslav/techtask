﻿using Shared.IServiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.Membership
{
    public class Person : IMembershipModel, ISendEmailModel
    {
        public string Name { get; set; }
        public DateTime DayOfstart { get; set ; }
        public MembershipAction MembershipAction { get; set; }
        public string Email { get; set; }
    }
}
