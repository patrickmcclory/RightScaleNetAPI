﻿using System.Collections.Generic;
using System.Management.Automation;
using RightScale.netClient;

namespace RightScale.netClient.Powershell
{
    #region deployments cmdlets
    [Cmdlet(VerbsCommon.Get, "RSDeployments")]
    public class deployments_index_show : Cmdlet
    {
        [Parameter(Position = 1, Mandatory = false)]
        public string deploymentID;

        [Parameter(Position = 2, Mandatory = false)]
        public string filter;

        [Parameter(Position = 3, Mandatory = false)]
        public string view;

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (deploymentID != null)
                {
                    Deployment rsDeployment = RightScale.netClient.Deployment.show(deploymentID);
                    WriteObject(rsDeployment);
                }
                else
                {
                    List<Filter> lstFilter = new List<Filter>();

                    if (filter != null)
                    {
                        Filter fltFilter = Filter.parseFilter(filter);
                        lstFilter.Add(fltFilter);
                    }

                    List<Deployment> rsDeployments = RightScale.netClient.Deployment.index(lstFilter, view);

                    WriteObject(rsDeployments);
                }
            }
            catch(RightScaleAPIException rex)
            {
                WriteObject(rex);
                WriteObject(rex.ErrorData);
            }
        }
    }

    //Consolidate to single index show method
    //[Cmdlet(VerbsCommon.Get, "RSDeployment")]
    //public class deployments_show : Cmdlet
    //{
    //
    //    [Parameter(Position = 1, Mandatory = true )]
    //    public string deploymentID;
    //
    //    protected override void ProcessRecord()
    //    {
    //        base.ProcessRecord();
    //        Deployment rsDeployment = RightScale.netClient.Deployment.show(deploymentID);
    //
    //        WriteObject(rsDeployment);
    //
    //    }
    //}
    #endregion

    #region deployments create / delete cmdlets
    [Cmdlet(VerbsCommon.New, "RSDeployment")]
    public class deployments_create : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true)]
        public string name;

        protected override void ProcessRecord()
        {
            Types.returnDeployment result = new Types.returnDeployment();

            base.ProcessRecord();
            string rsNewDeploymentID = RightScale.netClient.Deployment.create(name);

            if (rsNewDeploymentID != "")
            {
                result.Message = "Deployment created";
                result.Result = true;
                result.DeploymentID = rsNewDeploymentID;
                
                WriteObject(result);
            }
            else
            {
                result.Message = "Error creating deployment";
                result.Result = false;
                result.DeploymentID = rsNewDeploymentID;
                
                WriteObject(result);
            }
        }
    }

    [Cmdlet("Destroy", "RSDeployment")]
    public class deployments_destroy : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true)]
        public string deploymentID;
        
        protected override void ProcessRecord()
        {
            Types.returnDeployment retResult = new Types.returnDeployment();
            retResult.DeploymentID = deploymentID;

            base.ProcessRecord();
            bool rsRemoveDeployment = RightScale.netClient.Deployment.destroy(deploymentID);


            if (rsRemoveDeployment == true)
            {
                retResult.Message = "Deployment deleted";
                retResult.Result = rsRemoveDeployment;                

                WriteObject(retResult);
            }
            else
            {
                retResult.Message = "Error deleting deployment";
                retResult.Result = rsRemoveDeployment;

                WriteObject(retResult);
            }



        }
    }

    #endregion


}