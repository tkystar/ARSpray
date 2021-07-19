namespace kari
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityEngine.Networking;

    public class SpawninEditor : NetworkBehaviour
    {       
        
        public GameObject plane;
        GameObject spawnedplane;      
        public GameObject sharedobj;        
        bool once = true;                    
        private Renderer renderer;
        private Color[] textureBuffer;
        private Texture2D drawTexture;       
        public Color DrawColor =Color.blue;
        bool twice = false;


        void getrendrer()
        {
            
            Debug.Log("getrendrer");
            renderer = sharedobj.GetComponent<Renderer>();
            var bodyTexture = (Texture2D)renderer.material.mainTexture;
            var bodyPixels = bodyTexture.GetPixels();
            textureBuffer = new Color[bodyPixels.Length];
            bodyPixels.CopyTo(textureBuffer, 0);
            drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
            drawTexture.filterMode = FilterMode.Bilinear;
            drawTexture.SetPixels(textureBuffer);
            drawTexture.Apply();                                                                         ////SetPixel 関数と SetPixels 関数による変更を適用します
            renderer.material.mainTexture = drawTexture;
            
        }
        
        public Color changecolorblue()
        {
            DrawColor = Color.blue;
            return DrawColor;

        }
        public Color changecolorred()
        {
            DrawColor = Color.red;
            return DrawColor;
        }
        public void changecolorgreen()
        {
            DrawColor = Color.green;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(twice);

            if (once)
            {
                sharedobj = GameObject.Find("hogehoge");                              
            }
            
            if (sharedobj && once)  //GameObject.Find("hogehoge")
            {
                Debug.Log("sharedobj&& once");
                getrendrer();
                once = false;
            }


            if (Input.GetMouseButton(0) && once == false)
            {

             
                Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;               
                if (Physics.Raycast(ray, out hit, 2000))// && hit.collider.CompareTag("Player")
                {
                    var hitPoint = new Vector2(hit.textureCoord.x * drawTexture.width, hit.textureCoord.y * drawTexture.height);
                               
                    DrawPoint((int)hitPoint.x, (int)hitPoint.y, Color.blue);
                    CmdDrawPoint((int)hitPoint.x, (int)hitPoint.y, Color.blue);
                }
            }
      
            if (!isLocalPlayer)
            {
                return;
            }
            
            if (Input.GetMouseButtonUp(0)&&once)
            {              
                CmdSpawnPlane();
                
            }



            Debug.Log(twa)
;
        }
        bool twa;
        Vector2 GetMousePosInScreenPoint()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 screenPos = new Vector2(mousePos.x / Screen.width * drawTexture.width, mousePos.y / Screen.height * drawTexture.height);

            screenPos.x = Mathf.Clamp(screenPos.x, 0, drawTexture.width - 1);
            screenPos.y = Mathf.Clamp(screenPos.y, 0, drawTexture.height - 1);

            return screenPos;
        }

        // リセット
        public void ResetCanvas()
        {
            Color[] pixels = new Color[drawTexture.width * drawTexture.height];

            for (int y = 0; y < drawTexture.height; y++)
            {
                for (int x = 0; x < drawTexture.width; x++)
                {
                    pixels[drawTexture.width * y + x] = Color.white;
                }
            }

            drawTexture.SetPixels(pixels);
            drawTexture.Apply(); // Applyしないと、変更が反映されない


        }
        int xx;
        int yy;
        // 指定した点を塗る
        public void DrawPoint(int x, int y, Color color)
        {
            Debug.Log("DrawPoint");
            for (int i = 0; i <= 20; i++)
            {

                for (int theta = 0; theta <= 360; theta += Random.Range(5, 10))    // Random.Range(5, 10)
                {
                    xx = (int)(x + i * Mathf.Cos(theta));
                    yy = (int)(y + i * Mathf.Sin(theta));
                    drawTexture.SetPixel(xx, yy, color);

                }
            }

            drawTexture.Apply();
            
        }
        
        [Command]
        public void CmdSpawnPlane()
        {

            spawnedplane = Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
            //spawnedplane.name = "hogehoge";
            NetworkServer.Spawn(spawnedplane);

            
            this.RpcSpawnPlane(spawnedplane.GetComponent<NetworkIdentity>().netId,twice);
            
        }
        [ClientRpc]
        void RpcSpawnPlane(NetworkInstanceId instanceId,bool tw)
        {
            sharedobj = ClientScene.FindLocalObject(instanceId);
            sharedobj.name = "hogehoge";
            //Debug.Log("RpcSpawnPlane"+sharedobj.name);
            


        }
       

        [Command]
        public void CmdDrawPoint(int x, int y, Color color)
        {

            RpcDrawPoint(x,y,color);
           // Debug.Log("CmdDrawPoint");

        }
        
        [ClientRpc]
        void RpcDrawPoint(int x, int y, Color color)
        {
                //Debug.Log("RpcDrawPoint");
                for (int i = 0; i <= 20; i++)
                {

                    for (int theta = 0; theta <= 360; theta += Random.Range(5, 10))    // Random.Range(5, 10)
                    {
                        xx = (int)(x + i * Mathf.Cos(theta));
                        yy = (int)(y + i * Mathf.Sin(theta));
                    drawTexture.SetPixel(xx, yy, color);

                    }
                }

            drawTexture.Apply();
            renderer.material.mainTexture = drawTexture;
            
        }
      
    }
}