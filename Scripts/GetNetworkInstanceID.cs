namespace GoogleARCore.Examples.CloudAnchors     //名前空間
{


    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;

    public class GetNetworkInstanceID : NetworkBehaviour
    {
        //public static NetworkInstanceId instanceID;
        bool getid = false;
        // Start is called before the first frame update
        

        // Update is called once per frame
        /*
        void Update()
        {
            if (this && !getid)
            {
                instanceID = this.netId;
                GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().define(instanceID);
                getid = true;

            }
        }
        */

        public void returnNetID()
        {
            

            //GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().Cmdpixelnum(this.netId);
        }
    }
}