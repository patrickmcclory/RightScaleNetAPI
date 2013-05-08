﻿using System.Collections.Generic;
using System.Management.Automation;
using RightScale.netClient;

namespace RightScale.netClient.Powershell
{
    #region Instance index / show cmdlets
    [Cmdlet(VerbsCommon.Get, "RSInstances")]
    public class instance : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true)]
        public string cloudID;

        [Parameter(Position = 2, Mandatory = false)]
        public string instanceID;

        [Parameter(Position = 3, Mandatory = false)]
        public string filter;

        [Parameter(Position = 4, Mandatory = false)]
        public string view;

        protected override void ProcessRecord()
        {
            List<Filter> lstFilter = new List<Filter>();

            if (filter != null)
            {
                Filter fltFilter = Filter.parseFilter(filter);
                lstFilter.Add(fltFilter);
            }

            if (view == null) { view = "default"; }

            base.ProcessRecord();

            try
            {
                if (instanceID != null)
                {
                    Instance rsInstance = RightScale.netClient.Instance.show(cloudID, instanceID, view);
                    WriteObject(rsInstance);
                }
                else
                {
                    List<Instance> rsInstances = RightScale.netClient.Instance.index(cloudID, lstFilter, view);
                    WriteObject(rsInstances);
                }
            }
            catch (RightScaleAPIException rex)
            {
                WriteObject(rex.Message);
                WriteObject(rex.ErrorData);
                WriteObject(rex.APIHref);
            }

        }
    }

    //Moved to single get instance method
    //[Cmdlet(VerbsCommon.Get, "RSInstance")]
    //public class instance_show : Cmdlet
    //{
    //
    //    [Parameter(Position = 1, Mandatory = true)]
    //    public string cloudID;
    //
    //    [Parameter(Position = 2, Mandatory = true)]
    //    public string instanceID;
    //
    //    [Parameter(Position = 3, Mandatory = false)]
    //    public string view;
    //
    //    protected override void ProcessRecord()
    //    {
    //        if (view == null) { view = "default"; }
    //        base.ProcessRecord();
    //        Instance rsInstance = RightScale.netClient.Instance.show(cloudID,instanceID,view);
    //
    //        WriteObject(rsInstance);
    //
    //    }
    //}
    #endregion

    #region Instance run executable rightscripts chef cmdlets
    [Cmdlet("Run", "RSScript")]
    public class instance_runrsscript : Cmdlet
    {
        [Parameter(Position = 1, Mandatory = true)]
        public string cloudID;

        [Parameter(Position = 2, Mandatory = true)]
        public string instanceID;

        [Parameter(Position = 3, Mandatory = true)]
        public string rightScriptID;

        protected override void ProcessRecord()
        {

            Task rsRunScript = RightScale.netClient.Instance.run_rightScript(cloudID, instanceID, rightScriptID);

        }
    }
    #endregion

}