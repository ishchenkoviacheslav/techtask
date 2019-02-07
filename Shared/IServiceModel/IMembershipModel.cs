using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.IServiceModel
{
    public interface IMembershipModel
    {
        string Name { get; set; }
        DateTime DayOfstart { get; set; }
        MembershipAction MembershipAction { get; set; }
    }
}
