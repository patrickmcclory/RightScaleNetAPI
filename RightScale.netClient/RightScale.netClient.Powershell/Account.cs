﻿using System.Collections.Generic;
using System.Management.Automation;
using RightScale.netClient;

namespace RightScale.netClient.Powershell
{
    #region account show
    [Cmdlet(VerbsCommon.Get, "RSSAccount")]
    public class account : Cmdlet
    {
        [Parameter(Position = 1, Mandatory = false)]
        public string AccountID;

       

        protected override void ProcessRecord()
        {

            base.ProcessRecord();
            Account rsAccount = RightScale.netClient.Account.show(AccountID);

            WriteObject(rsAccount);

        }
    }
    #endregion

}