namespace kari
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityEngine.Networking;

    public class SpawnEditor2 : NetworkBehaviour
    {

        public GameObject plane;
        GameObject spawnedplane;
        public GameObject sharedobj;
        bool once = true;
        private Renderer renderer;
        private Color[] textureBuffer;
        private Texture2D drawTexture;
        public Color DrawColor = Color.blue;



        void getrendrer()
        {
            Debug.Log("getrendrer");
            renderer = GameObject.Find("hogehoge").GetComponent<Renderer>();
            var bodyTexture = (Texture2D)renderer.material.mainTexture;
            var bodyPixels = bodyTexture.GetPixels();
            textureBuffer = new Color[bodyPixels.Length];
            bodyPixels.CopyTo(textureBuffer, 0);
            drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
            drawTexture.filterMode = FilterMode.Bilinear;
            drawTexture.SetPixels(textureBuffer);
            drawTexture.Apply();                                                                         ////SetPixel 関数と SetPixels 関数による変更を適用します
            renderer.material.mainTexture = drawTexture;
            once = false;
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
       
        public void anan()
        {

            //script = colorselector.GetComponent<ColorSelector>();
            //DrawColor = script.finalColor;

            Text status_text = GameObject.Find("DrawingStatusText").GetComponent<Text>();
            status_text.text = "Drawing Now.....!";

            //コメントアウト中
            Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //if (Physics.Raycast(arcamera.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            if (Physics.Raycast(ray, out hit, 3000))// && hit.collider.CompareTag("Player")
            {

                var hitPoint = new Vector2(hit.textureCoord.x * drawTexture.width, hit.textureCoord.y * drawTexture.height);
                int distance = (int)(hit.distance * 70);
                Text ditance_text = GameObject.Find("DistanceText").GetComponent<Text>();
                ditance_text.text = "kyoriha" + distance;
                /*
                if (d < 300)
                {*/
                DrawPoint((int)hitPoint.x, (int)hitPoint.y, Color.blue, distance);


                CmdDrawPoint((int)hitPoint.x, (int)hitPoint.y, Color.blue, distance);
            }
        }
        // Update is called once per frame
        void Update()
        {



            

            if (once && GameObject.Find("hogehoge"))
            {
                getrendrer();

            }
            /*
            if (once && GameObject.Find("hogehoge"))
            {
                renderer.material.mainTexture = drawTexture;
            }*/
            // 他人のプレイヤーに対しては何も行わない
            if (!isLocalPlayer)
            {
                return;
            }

            if (Input.GetMouseButtonUp(0) && once == true)
            {
                CmdSpawnPlane();
            }




        }
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
        public void DrawPoint(int x, int y, Color color, int d)
        {
            Debug.Log("DrawPoint");
            for (int i = 0; i <= d; i++)
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

        [Command]
        public void CmdSpawnPlane()
        {

            spawnedplane = Instantiate(plane, new Vector3(0, 0, 0), Quaternion.identity);
            //spawnedplane.name = "hogehoge";
            NetworkServer.Spawn(spawnedplane);


            this.RpcSpawnPlane(spawnedplane.GetComponent<NetworkIdentity>().netId);

        }
        [ClientRpc]
        void RpcSpawnPlane(NetworkInstanceId instanceId)
        {
            sharedobj = ClientScene.FindLocalObject(instanceId);
            sharedobj.name = "hogehoge";
            Debug.Log("RpcSpawnPlane" + sharedobj.name);
        }

        [Command]
        public void CmdDrawPoint(int x, int y, Color color, int d)
        {

            RpcDrawPoint(x, y, color,d);
            Debug.Log("CmdDrawPoint");

        }

        [ClientRpc]
        void RpcDrawPoint(int x, int y, Color color, int d)
        {
            Debug.Log("RpcDrawPoint");
            for (int i = 0; i <= d; i++)
            {

                for (int theta = 0; theta <= 360; theta += 1)    // Random.Range(5, 10)
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