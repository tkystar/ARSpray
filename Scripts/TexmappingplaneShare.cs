namespace networktest { 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


    public class TexmappingplaneShare : NetworkBehaviour
    {
        public GameObject planePrefab;
        // Start is called before the first frame update
        [Command]
#pragma warning restore 618
        public void CmdSpawnplane()
        {
            // Instantiate Star model at the hit pose.
            var starObject = Instantiate(planePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //StarPrefab.transform.position = Camera.transform.TransformPoint(0, 0, 0.5f);
            //StarPrefab.AddComponent<Rigidbody>();
            //StarPrefab.GetComponent<Rigidbody>().AddForce(Camera.transform.TransformDirection(0, 1f, 2f), ForceMode.Impulse);

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject); //Spawn(starObject);

#pragma warning restore 618
        }
    }

}
