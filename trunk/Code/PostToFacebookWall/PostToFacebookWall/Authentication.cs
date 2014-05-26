using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImpactWorks.FBGraph.Connector;
using ImpactWorks.FBGraph.Core;

namespace PostToFacebookWall
{
    public class Authentication
    {
        public Facebook FacebookAuth()
        {
            //Setting up the facebook object
            Facebook facebook = new Facebook(); 
            facebook.AppID = "121151448076995";
            facebook.CallBackURL = "http://localhost:1846/PostStatus/Success/";
            facebook.Secret = "faad2213088bf6131d28b8944251d400";

            //Setting up the permissions
            List<FBPermissions> permissions = new List<FBPermissions>() {
                FBPermissions.user_about_me, // to read about me               
                FBPermissions.user_events,
                FBPermissions.user_status,
                FBPermissions.read_stream,
                FBPermissions.friends_events,
                FBPermissions.publish_stream
            };

            //Pass the permissions object to facebook instance
            facebook.Permissions = permissions;
            return facebook;
        }
    }
}