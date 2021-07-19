//-----------------------------------------------------------------------
// <copyright file="LocalPlayerController.cs" company="Google">
//
// Copyright 2018 Google LLC. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.CloudAnchors     //名前空間
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Networking;
    using System.Collections.Generic;
    using GoogleARCore;
    using GoogleARCore.Examples.Common;
    using UnityEngine.EventSystems;


    /// <summary>
    /// Local player controller. Handles the spawning of the networked Game Objects.
    /// </summary>
#pragma warning disable 618
    public class LocalPlayerController : NetworkBehaviour
#pragma warning restore 618
    {
        //private NetworkInstanceId playerNetID;
        /// <summary>
        /// The Star model that will represent networked objects in the scene.
        /// </summary>
        public GameObject AnchorPrefab;
        public GameObject PlanePrefab;
        public Color DrawColor = Color.cyan;
        private Renderer renderer;
        public Texture2D drawTexture;              
        public Color[] textureBuffer;       
        bool once = true;       
        AudioSource spawnsound;
        public GameObject ColorSelector;
        public GameObject SprayCan;
        /*
        private List<DetectedPlane> m_newPlanes = new List<DetectedPlane>();        
        private List<DetectedPlane> m_allPlanes = new List<DetectedPlane>();

        private Color[] m_planeColors = new Color[] {
            new Color (1.0f, 1.0f, 1.0f),
            new Color (0.956f, 0.262f, 0.211f),
            new Color (0.913f, 0.117f, 0.388f),
            new Color (0.611f, 0.152f, 0.654f),
            new Color (0.403f, 0.227f, 0.717f),
            new Color (0.247f, 0.317f, 0.709f),
            new Color (0.129f, 0.588f, 0.952f),
            new Color (0.011f, 0.662f, 0.956f),
            new Color (0f, 0.737f, 0.831f),
            new Color (0f, 0.588f, 0.533f),
            new Color (0.298f, 0.686f, 0.313f),
            new Color (0.545f, 0.764f, 0.290f),
            new Color (0.803f, 0.862f, 0.223f),
            new Color (1.0f, 0.921f, 0.231f),
            new Color (1.0f, 0.756f, 0.027f)
        };*/

        Texture2D bodyTexture;
        GameObject sharedobj;
        Color[] bodyPixels;
        public NetworkManagerUIController NetworkUIController;
        private void Start()
        {
            spawnsound = this.gameObject.GetComponent<AudioSource>();
        }

        
        public GameObject Hogehoge;
        void getrendrer()
        {
            renderer = sharedobj.GetComponent<Renderer>();
            var bodyTexture = (Texture2D)renderer.material.mainTexture;
            var bodyPixels = bodyTexture.GetPixels();
            textureBuffer = new Color[bodyPixels.Length];
            bodyPixels.CopyTo(textureBuffer, 0);
            drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
            drawTexture.filterMode = FilterMode.Trilinear;
            drawTexture.SetPixels(textureBuffer);          
            drawTexture.Apply();                                                                          ////SetPixel 関数と SetPixels 関数による変更を適用します.変更しても適用(Apply)しないと反映されない
            renderer.material.mainTexture = drawTexture;
            
        }
       

        public void standard(Color DrawColor)
        {
            drawTexture = (Texture2D)renderer.material.mainTexture;          
            Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
            var ray = Camera.main.ScreenPointToRay(center);
            RaycastHit hit;          
            if (Physics.Raycast(ray, out hit, 50)&& hit.collider.CompareTag("Player"))
            {

                var hitPoint = new Vector2(hit.textureCoord.x * drawTexture.width, hit.textureCoord.y * drawTexture.height);
                int distance = (int)(hit.distance * 25);

                //DrawPoint((int)hitPoint.x, (int)hitPoint.y, DrawColor, distance);
                DrawPoint(hitPoint.x, hitPoint.y, DrawColor, distance);
                CmdDrawPoint(hitPoint.x, hitPoint.y, DrawColor, distance);
            }
        }
        
        
        void Update()
        {
            
            if (once)
            {
                sharedobj = GameObject.Find("hogehoge");              
            }

            if (sharedobj&&once)  
            {
                detectedplanes = GameObject.Find("ARCore World Origin Helper").GetComponent<ARCoreWorldOriginHelper>().planeObject;
                detectedplanes.SetActive(false);
                once = false;
                getrendrer();
                ColorSelector.SetActive(true);
                SprayCan.SetActive(true);

            }           
            if (!isLocalPlayer)
            {
                return;
            }

        }
        public void ResetCanvas()            //キャンバスリセット機能つけたければこの関数使う
        {
            
            Color[] pixels = new Color[drawTexture.width * drawTexture.height];

            for (int y = 0; y < drawTexture.height; y++)
            {
                for (int x = 0; x < drawTexture.width; x++)
                {
                    pixels[drawTexture.width * y + x] = new Color(0, 0, 0, 0);
                }
            }

            drawTexture.SetPixels(pixels);
            drawTexture.Apply(); // Applyしないと、変更が反映されない
            /*
            AudioSource audio=this.gameObject.GetComponent<AudioSource>();
            audio.Play();
            */
        }

        // 指定した点を塗る
        public void DrawPoint(float x, float y, Color color,int d)
        {
            Debug.Log("GG");
            for (float i = 0; i <= d; i+=0.8f)
            {

                for (int theta = 0; theta < 360; theta += Random.Range(30, 50))    // Random.Range(5, 10)
                {
                    int xx = (int)(x + i * Mathf.Cos(theta));
                    int yy = (int)(y + i * Mathf.Sin(theta));
                    drawTexture.SetPixel(xx, yy, color);

                }
            }

            drawTexture.Apply();
            
        }
       
        /// <summary>
        /// The Anchor model that will represent the anchor in the scene.
        /// </summary>
       

        /// <summary>
        /// The Unity OnStartLocalPlayer() method.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            // A Name is provided to the Game Object so it can be found by other Scripts, since this
            // is instantiated as a prefab in the scene.
            gameObject.name = "LocalPlayer";

            //GetNetIdentity();
        }

        /// <summary>
        /// Will spawn the origin anchor and host the Cloud Anchor. Must be called by the host.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
        /// <param name="anchor">The ARCore Anchor to be hosted.</param>
        public void SpawnAnchor(Vector3 position, Quaternion rotation, Component anchor)
        {
            // Instantiate Anchor model at the hit pose.
            var anchorObject = Instantiate(AnchorPrefab, position, rotation);

            // Anchor must be hosted in the device.
            anchorObject.GetComponent<AnchorController>().HostLastPlacedAnchor(anchor);

            // Host can spawn directly without using a Command because the server is running in this
            // instance.
#pragma warning disable 618
            NetworkServer.Spawn(anchorObject);
            spawnsound.Play();
#pragma warning restore 618
        }
        GameObject starObject;  

        /// <summary>
        /// A command run on the server that will spawn the Star prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnStar(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
           starObject = Instantiate(PlanePrefab, position, rotation);
            starObject.name = "hogehoge";
            
            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject);                               
            spawnsound.Play();
            this.RpcSpawnStar(starObject.GetComponent<NetworkIdentity>().netId);
#pragma warning restore 618
        }

        GameObject detectedplanes;
        [ClientRpc]
        void RpcSpawnStar(NetworkInstanceId instanceId)
        {
            sharedobj = ClientScene.FindLocalObject(instanceId);
            sharedobj.name = "hogehoge";

        }

        [Command]
        public void CmdDrawPoint(float x, float y, Color color,int d)
        {
            RpcDrawPoint(x, y, color,d);
        }

        [ClientRpc]
        void RpcDrawPoint(float x, float y, Color color,int d)
        {
           
            for (float i = 0; i <= d; i+=0.8f)
            {
                for (int theta = 0; theta <= 360; theta += Random.Range(30, 50))    // Random.Rangeは調整すべし
                {
                    int xx = (int)(x + i * Mathf.Cos(theta));
                    int yy = (int)(y + i * Mathf.Sin(theta));
                    drawTexture.SetPixel(xx, yy, color);
                }
            }

            drawTexture.Apply();
            renderer.material.mainTexture = drawTexture;               
            
        }


    }
}
