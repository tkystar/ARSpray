using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine.EventSystems;

public class Authoritytest : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]

    public void CmdAuthority()
    {
        RpcAuthority();
    }
    [ClientRpc]
    void RpcAuthority()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
