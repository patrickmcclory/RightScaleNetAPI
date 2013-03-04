﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightScale.netClient
{
    class InstanceCustomLodgement
    {
        //TODO: need to write this class

        
        #region InstanceCustomLodgement.index methods

        public static List<InstanceCustomLodgement> index()
        {
            return index(null, null);
        }

        public static List<InstanceCustomLodgement> index(List<KeyValuePair<string, string>> filter)
        {
            return index(filter, null);
        }

        public static List<InstanceCustomLodgement> index(string view)
        {
            return index(null, view);
        }

        public static List<InstanceCustomLodgement> index(List<KeyValuePair<string, string>> filter, string view)
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

            List<string> validFilters = new List<string>() { "timeframe" };
            Utility.CheckFilterInput("filter", validFilters, filter);

            //TODO: implement InstanceCustomLodgement.index
            throw new NotImplementedException();
        }
        #endregion
		
    }


}
