﻿using Shared.IServiceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class MembershipService: IService<IMembershipModel>
    {
        public void CreateNewMemberOrUpdate(string name, DateTime date, MembershipAction action)
        {
            if(MembershipAction.Update == action)
                Console.WriteLine("Update membership");
            else
                Console.WriteLine("Create new membership");
        }
        //public void CallService(string abs, DateTime time, MembershipAction membershipAction)
        public void CallService(IMembershipModel membershipModel)
        {
            CreateNewMemberOrUpdate(membershipModel.Name, membershipModel.DayOfstart, membershipModel.MembershipAction);
        }
    }
}
