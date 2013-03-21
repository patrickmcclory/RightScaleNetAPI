﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightScale.netClient
{
    /// <summary>
    /// Object defines the data related to the attachment of a volume to an instance
    /// MediaType Reference: http://reference.rightscale.com/api1.5/media_types/MediaTypeVolumeAttachment.html
    /// Resource Reference: http://reference.rightscale.com/api1.5/resources/ResourceVolumeAttachments.html
    /// </summary>
    public class VolumeAttachment:Core.RightScaleObjectBase<VolumeAttachment>
    {
        #region VolumeAttachment properties

        /// <summary>
        /// Device for this VolumeAttachment
        /// </summary>
        public string device { get; set; }

        /// <summary>
        /// RightScale resource unique identifier for this Volume Attachment
        /// </summary>
        public string resource_uid { get; set; }

        /// <summary>
        /// Datetime when this VolumeAttachment was created
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// Datetime when this VolumeAttachment was last updated
        /// </summary>
        public string updated_at { get; set; }

        /// <summary>
        /// Device ID of this volume Attachment
        /// </summary>
        public string device_id { get; set; }

        /// <summary>
        /// Current state of this Volume Attachment
        /// </summary>
        public string state { get; set; }

        #endregion

        #region VolumeAttachment relationships

        /// <summary>
        /// Associated Volume
        /// </summary>
        public Volume volume
        {
            get
            {
                string jsonString = Core.APIClient.Instance.Get(getLinkValue("volume"));
                return Volume.deserialize(jsonString);
            }
        }

        /// <summary>
        /// Associated Instance
        /// </summary>
        public Instance instance
        {
            get
            {
                string jsonString = Core.APIClient.Instance.Get(getLinkValue("instance"));
                return Instance.deserialize(jsonString);
            }
        }

        /// <summary>
        /// Associated Cloud
        /// </summary>
        public Cloud cloud
        {
            get
            {
                string jsonString = Core.APIClient.Instance.Get(getLinkValue("cloud"));
                return Cloud.deserialize(jsonString);
            }
        }

        #endregion

        #region VolumeAttachment.ctor
        /// <summary>
        /// Default Constructor for VolumeAttachment
        /// </summary>
        public VolumeAttachment()
            : base()
        {
        }

        /// <summary>
        /// Constructor for VolumeAttachment object that takes in an oAuth Refresh token for RSAPI Authentication purposes
        /// </summary>
        /// <param name="oAuthRefreshToken">RightScale OAuth Refresh Token</param>
        public VolumeAttachment(string oAuthRefreshToken)
            : base(oAuthRefreshToken)
        {
        }

        /// <summary>
        /// Cosntructor for VolumeAttachment object that takes username, password and accountno for RSAPI Authentication purposes
        /// </summary>
        /// <param name="userName">RightScale user name</param>
        /// <param name="password">RightScale user password</param>
        /// <param name="accountNo">RightScale account to be accessed programmatically</param>
        public VolumeAttachment(string userName, string password, string accountNo)
            : base(userName, password, accountNo)
        {
        }

        #endregion

        #region VolumeAttachment.index methods

        /// <summary>
        /// Lists all volume attachments
        /// </summary>
        /// <param name="cloudID">ID of the cloud to query</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index(string cloudID)
        {
            return index(cloudID, null, null);
        }

        /// <summary>
        /// Lists all volume attachments
        /// </summary>
        /// <param name="cloudID">ID fo the cloud to query</param>
        /// <param name="filter">Set of filters for query</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index(string cloudID, List<Filter> filter)
        {
            return index(cloudID, filter, null);
        }

        /// <summary>
        /// Lists all volume attachments
        /// </summary>
        /// <param name="cloudID">ID of the cloud to query</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index(string cloudID, string view)
        {
            return index(cloudID, null, view);
        }

        /// <summary>
        /// Lists all volume attachments
        /// </summary>
        /// <param name="cloudID">ID of the cloud to query</param>
        /// <param name="filter">Set of filters for query</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index(string cloudID, List<Filter> filter, string view)
        {
            string getHref = string.Format(APIHrefs.VolumeAttachment, cloudID);
            return indexGet(getHref, filter, view);
        }

        /// <summary>
        /// Lists all Volume Attachments for an Instance
        /// </summary>
        /// <param name="cloudID">ID of the Cloud being queried</param>
        /// <param name="instanceID">Id of the Instance being queried</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index_Instance(string cloudID, string instanceID)
        {
            return index_Instance(cloudID, instanceID, new List<Filter>(), string.Empty);
        }

        /// <summary>
        /// Lists all Volume Attachments for an Instance
        /// </summary>
        /// <param name="cloudID">ID of the Cloud being queried</param>
        /// <param name="instanceID">Id of the Instance being queried</param>
        /// <param name="filter">Set of filters for query</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index_Instance(string cloudID, string instanceID, List<Filter> filter)
        {
            return index_Instance(cloudID, instanceID, filter, string.Empty);
        }

        /// <summary>
        /// Lists all Volume Attachments for an Instance
        /// </summary>
        /// <param name="cloudID">ID of the Cloud being queried</param>
        /// <param name="instanceID">Id of the Instance being queried</param>
        /// <param name="view">Specifies how many attributes and/or expanded ne
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index_Instance(string cloudID, string instanceID, string view)
        {
            return index_Instance(cloudID, instanceID, new List<Filter>(), view);
        }

        /// <summary>
        /// Lists all Volume Attachments for an Instance
        /// </summary>
        /// <param name="cloudID">ID of the Cloud being queried</param>
        /// <param name="instanceID">Id of the Instance being queried</param>
        /// <param name="filter">Set of filters for query</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>List of VolumeAttachment objects</returns>
        public static List<VolumeAttachment> index_Instance(string cloudID, string instanceID, List<Filter> filter, string view)
        {
            string getHref = string.Format(APIHrefs.InstanceVolumeAttachment, cloudID, instanceID);
            return indexGet(getHref, filter, view);
        }

        /// <summary>
        /// Private method managing central process for getting list of VolumeAttachment classes
        /// </summary>
        /// <param name="getHref">API Href fragment for RSAPI call</param>
        /// <param name="filter">collection of filters for this request</param>
        /// <param name="view">View specified for this request</param>
        /// <returns>List of VolumeAttachmemt objects</returns>
        private static List<VolumeAttachment> indexGet(string getHref, List<Filter> filter, string view)
        {
            if (string.IsNullOrWhiteSpace(view))
            {
                view = "default";
            }
            else
            {
                List<string> validViews = new List<string>() { "default" };
                Utility.CheckStringInput("view", validViews, view);
            }

            List<string> validFilters = new List<string>() { "instance_href", "resource_uid", "volume_href" };
            Utility.CheckFilterInput("filter", validFilters, filter);
            string queryString = string.Empty;

            foreach (Filter f in filter)
            {
                queryString += f.ToString() + "&";
            }
            queryString += string.Format("view={0}", view);

            string jsonString = Core.APIClient.Instance.Get(getHref, queryString);
            return deserializeList(jsonString);
        }
        #endregion

        #region VolumeAttachment.show methods

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="instanceID">ID of instance where VolumeAttachment is located</param>
        /// <param name="volumeID">ID of Volume for VolumeAttachment</param>
        /// <returns><Instance of VolumeAttachment/returns>
        public static VolumeAttachment show_Instance(string cloudID, string instanceID, string volumeID)
        {
            return show_Instance(cloudID, instanceID, volumeID, string.Empty);
        }

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="instanceID">ID of instance where VolumeAttachment is located</param>
        /// <param name="volumeID">ID of Volume for VolumeAttachment</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>Instance of VolumeAttachment</returns>
        public static VolumeAttachment show_Instance(string cloudID, string instanceID, string volumeID, string view)
        {
            string getHref = string.Format(APIHrefs.InstanceVolumeAttachmentByID, cloudID, instanceID, volumeID);
            return showGet(getHref, view);
        }

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="volumeAttachmentID">ID of VolumeAttachment</param>
        /// <returns>Instance of VolumeAttachment</returns>
        public static VolumeAttachment show(string cloudID, string volumeAttachmentID)
        {
            return show(cloudID, volumeAttachmentID, string.Empty);
        }

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="volumeAttachmentID">ID of VolumeAttachment</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>Instance of VolumeAttachment</returns>
        public static VolumeAttachment show(string cloudID, string volumeAttachmentID, string view)
        {
            string getHref = string.Format(APIHrefs.VolumeAttachmentByID, cloudID, volumeAttachmentID);
            return showGet(getHref, view);
        }

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="volumeID">ID of Volume for VolumeAttachment</param>
        /// <returns>Instance of VolumeAttachment</returns>
        public static VolumeAttachment show_Volume(string cloudID, string volumeID)
        {
            return show_Volume(cloudID, volumeID, string.Empty);
        }

        /// <summary>
        /// Displays information about a single volume attachment
        /// </summary>
        /// <param name="cloudID">ID of cloud where VolumeAttachment is located</param>
        /// <param name="volumeID">ID of Volume for VolumeAttachment</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>Instance of VolumeAttachment</returns>
        public static VolumeAttachment show_Volume(string cloudID, string volumeID, string view)
        {
            string getHref = string.Format(APIHrefs.VolumeVolumeAttachments, cloudID, volumeID);
            return showGet(getHref, view);
        }

        /// <summary>
        /// Private method for centralizing logic for getting a VolumeAttachment object
        /// </summary>
        /// <param name="getHref">href fragment for making calls to the RSAPI</param>
        /// <param name="view">Specifies how many attributes and/or expanded nested relationships to include</param>
        /// <returns>Instance of VolumeAttachment</returns>
        private static VolumeAttachment showGet(string getHref, string view)
        {
            if (string.IsNullOrWhiteSpace(view))
            {
                view = "default";
            }
            else
            {
                List<string> validViews = new List<string>() { "default" };
                Utility.CheckStringInput("view", validViews, view);
            }

            string queryStringValue = string.Format("view={0}", view);
            string jsonString = Core.APIClient.Instance.Get(getHref, queryStringValue);
            return deserialize(jsonString);
        }
        #endregion

        #region VolumeAttachment.create methods

        /// <summary>
        /// Creates a new Volume Attachment
        /// </summary>
        /// <param name="cloudID">ID of Cloud</param>
        /// <param name="device">The device location where the volume will be mounted. Value must be of format /dev/xvd[bcefghij]. This is not reliable and will be deprecated</param>
        /// <param name="instanceID">The ID of the instance to which the volume will be attached to</param>
        /// <param name="volumeID">The ID of the volume to be attached</param>
        /// <returns>ID of newly created VolumeAttachment</returns>
        public static string create(string cloudID, string device, string instanceID, string volumeID)
        {
            string postHref = string.Format(APIHrefs.VolumeAttachment, cloudID);
            return createPost(postHref, cloudID, device, instanceID, volumeID);
        }

        /// <summary>
        /// Creates a new Volume Attachment
        /// </summary>
        /// <param name="cloudID">ID of Cloud</param>
        /// <param name="instanceID">The ID of the instance to which the volume will be attached to</param>
        /// <param name="device">The device location where the volume will be mounted. Value must be of format /dev/xvd[bcefghij]. This is not reliable and will be deprecated</param>
        /// <param name="volumeID">The ID of the volume to be attached</param>
        /// <returns>ID of newly created VolumeAttachment</returns>
        public static string create_Instance(string cloudID, string instanceID, string device, string volumeID)
        {
            string postHref = string.Format(APIHrefs.InstanceVolumeAttachment, cloudID, instanceID);
            return createPost(postHref, cloudID, device, instanceID, volumeID);
        }

        /// <summary>
        /// Creates a new Volume Attachment
        /// </summary>
        /// <param name="cloudID">ID of Cloud</param>
        /// <param name="volumeID">The ID of the volume to be attached</param>
        /// <param name="device">The device location where the volume will be mounted. Value must be of format /dev/xvd[bcefghij]. This is not reliable and will be deprecated</param>
        /// <param name="instanceID">The ID of the instance to which the volume will be attached to</param>
        /// <returns>ID of newly created VolumeAttachment</returns>
        public static string create_Volume(string cloudID, string volumeID, string device, string instanceID)
        {
            string postHref = string.Format(APIHrefs.VolumeVolumeAttachments, cloudID, volumeID);
            return createPost(postHref, cloudID, device, instanceID, volumeID);
        }

        /// <summary>
        /// Private method for centralizing all logic for VolumeAttachment Create clals
        /// </summary>
        /// <param name="postHref">Href fragment for calling RSAPI</param>
        /// <param name="cloudID">ID of Cloud</param>
        /// <param name="device">The device location where the volume will be mounted. Value must be of format /dev/xvd[bcefghij]. This is not reliable and will be deprecated</param>
        /// <param name="instanceID">The ID of the instance to which the volume will be attached to</param>
        /// <param name="volumeID">The ID of the volume to be attached</param>
        /// <returns>ID of newly created VolumeAttachment</returns>
        private static string createPost(string postHref, string cloudID, string device, string instanceID, string volumeID)
        {
            List<KeyValuePair<string,string>> inputs = new List<KeyValuePair<string,string>>();
            inputs.Add(new KeyValuePair<string,string>("device", device));
            inputs.Add(new KeyValuePair<string,string>("instance_href", Utility.InstanceHref(cloudID, instanceID)));
            inputs.Add(new KeyValuePair<string, string>("volume_href", Utility.VolumeHref(cloudID, volumeID)));
            string outString = string.Empty;

            List<string> retVal = Core.APIClient.Instance.Post(postHref, inputs,"location", out outString);
            return retVal.Last<string>().Split('/').Last<string>();
        }

        #endregion
    }
}
