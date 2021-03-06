﻿using System.Collections.Generic;
using System.Management.Automation;
using RightScale.netClient;

namespace RightScale.netClient.Powershell
{
    //API
    //by_resource
    //by_tag
    //multi_add
    //multi_delete

    #region Tags byHref
    /// <summary>
    /// Get RSTags by href
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "RSTagsByHref")]
    public class tags_byhref : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true)]
        public string href;       

        protected override void ProcessRecord()
        {
           
            List<RightScale.netClient.Tag> rsTags = RightScale.netClient.Tag.byResource(href);

            WriteObject(rsTags);

        }
    }

    #endregion

    #region Tags byResource
    /// <summary>
    /// Get RSTags by href
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "RSTagsByTag")]
    public class tags_byresource : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true)]
        public string prefix;

        [Parameter(Position = 2, Mandatory = true)]
        public bool matchAll;

        [Parameter(Position = 3, Mandatory = true)]
        public string resourceType;

        //scope,name,value
        [Parameter(Position = 4, Mandatory = true)]
        public string[] tags;

        protected override void ProcessRecord()
        {
            List<Tag> lstTags = new List<Tag>();

            foreach (string tag in tags)
            {
                Tag srchTag = new Tag(tag);
                lstTags.Add(srchTag);
            }


            try
            {

                List<Resource> rsResources = RightScale.netClient.Tag.byTag(prefix, matchAll, resourceType, lstTags);
                WriteObject(rsResources);
            }
            catch (RightScaleAPIException rsEx)
            {
                WriteObject(rsEx);
            }
            catch (System.Exception genEx)
            {
                WriteObject(genEx);

            }
           

        }
    }

    #endregion

    #region Tags Create - multi_add
    /// <summary>
    /// Create RS Tags
    /// Tag format - predicate:name=value
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "RSTags")]
    public class tags_set : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true,HelpMessage="HREF of object to apply tags to")]
        public string href;

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Array of Tags to add")]
        public string[] tags;

        protected override void ProcessRecord()
        {
            List<string> resourceHrefs = new List<string>() {href};
            List<Tag> lstTags = new List<Tag>();

            foreach(string tag in tags)
            {
                Tag newTag = new Tag(tag);
                lstTags.Add(newTag);
            }

            try
            {
                bool result = Tag.multiAdd(resourceHrefs, lstTags);
                              
                WriteObject("Tag added");
                WriteObject(result);
            }
            catch (RightScaleAPIException rsEx)
            {
                Types.returnTagAction retTag = new Types.returnTagAction();

                retTag.tagAction = "Add Tag";
                retTag.href = href;
                retTag.Result =false;
                retTag.APIHref = rsEx.APIHref;
                retTag.Message = "Error Adding Tag";
                retTag.Details = rsEx.ErrorData;

                WriteObject(retTag);
            }
            catch (System.Exception genEx)
            {
                Types.returnTagAction retTag = new Types.returnTagAction();

                retTag.tagAction = "Add Tag";
                retTag.href = href;
                retTag.Result = false;
                retTag.APIHref = genEx.Message;
                retTag.Message = "Error Adding Tag";
                retTag.Details = genEx.InnerException.Message;

                WriteObject(retTag);
            }
        }
    }
    #endregion

    #region Tags Create - multi_delete
    /// <summary>
    /// Create RS Tags
    /// Tag format - predicate:name=value
    /// </summary>
    [Cmdlet("Delete", "RSTags")]
    public class tags_delete : Cmdlet
    {

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "HREF of object to apply tags to")]
        public string href;

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Array of Tags to delete")]
        public string[] tags;

        protected override void ProcessRecord()
        {
            List<string> resourceHrefs = new List<string>() { href };
            List<Tag> lstTags = new List<Tag>();

            foreach (string tag in tags)
            {
                Tag newTag = new Tag(tag);
                lstTags.Add(newTag);
            }

            try
            {
                bool result = Tag.multiDelete(resourceHrefs, lstTags);

                WriteObject("Tags deleted");
                WriteObject(result);
            }
            catch (RightScaleAPIException rsEx)
            {
                WriteObject("Error deleting tag");
                WriteObject(rsEx);
            }
            catch (System.Exception genEx)
            {
                WriteObject("Error deleting tag");
                WriteObject(genEx);
            }
        }
    }
    #endregion
}