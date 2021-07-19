namespace kari
{

    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using UnityEngine.Networking;
    using UnityEngine.Networking.NetworkSystem;


    public class OE : MonoBehaviour
    {
        GameObject skrillex;
        private Renderer renderer;
        public Color[] textureBuffer;
        public SpawninEditor SpawninEditor;
        
        public Texture2D texture;
        bool a;

        void PlaneInfoSet()
        {
            renderer = skrillex.gameObject.GetComponent<Renderer>();
            var bodyTexture = (Texture2D)renderer.material.mainTexture;
            var bodyPixels = bodyTexture.GetPixels();
            textureBuffer = new Color[bodyPixels.Length];
            bodyPixels.CopyTo(textureBuffer, 0);
            texture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
            texture.filterMode = FilterMode.Bilinear;
            texture.SetPixels(textureBuffer);
            texture.Apply();                                                                         ////SetPixel 関数と SetPixels 関数による変更を適用します
            renderer.material.mainTexture = texture;
            // テクスチャーを生成
            //texture = new Texture2D(256, 256);
            // 補間無し
            //texture.filterMode = FilterMode.Bilinear;
            // 白で塗りつぶし
            //ResetCanvas();

            // RawImageにテクスチャーを設定
            //GetComponent<RawImage>().texture = texture;
            //planeprehab.GetComponent<Renderer>().material.mainTexture = texture;
            a = true;
        }


        void Update()
        {

            /*
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Debug.Log("GG");
                return;
            }*/
            /*
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }*/
            skrillex = GameObject.Find("hogehoge");

            if (skrillex != null && !a)
            {
                PlaneInfoSet();
                Debug.Log("planeinfoset");
            }

            // Rキーでリセット
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetCanvas();

                // リセットしたことをサーバーへ通知
                //client.Send(oekakiMsg.Reset, new EmptyMessage());
            }

            // マウス左ボタンで描画

            if (Input.GetMouseButton(0) && a == true)
            {


                Debug.Log("DD");
                Vector2 screenPos = GetMousePosInScreenPoint();
                DrawPoint((int)screenPos.x, (int)screenPos.y, Color.blue);   //ここで素でに描画

                // 点を描画したことをサーバーへ通知
                SpawninEditor.CmdDrawPoint((int)screenPos.x, (int)screenPos.y, Color.blue);

                

            }

        }

        // マウスの場所をスクリーン座標（というかテクスチャー上での座標）で取得する
        Vector2 GetMousePosInScreenPoint()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 screenPos = new Vector2(mousePos.x / Screen.width * texture.width, mousePos.y / Screen.height * texture.height);

            screenPos.x = Mathf.Clamp(screenPos.x, 0, texture.width - 1);
            screenPos.y = Mathf.Clamp(screenPos.y, 0, texture.height - 1);

            return screenPos;
        }

        // リセット
        public void ResetCanvas()
        {
            Color[] pixels = new Color[texture.width * texture.height];

            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    pixels[texture.width * y + x] = Color.white;
                }
            }

            texture.SetPixels(pixels);
            texture.Apply(); // Applyしないと、変更が反映されない

            
        }
        int xx;
        int yy;
        // 指定した点を塗る
        void DrawPoint(int x, int y, Color color)
        {
            Debug.Log("GG");
            for (int i = 0; i <= 20; i++)
            {

                for (int theta = 0; theta <= 360; theta += 1)    // Random.Range(5, 10)
                {
                    xx = (int)(x + i * Mathf.Cos(theta));
                    yy = (int)(y + i * Mathf.Sin(theta));
                    texture.SetPixel(xx, yy, color);

                }
            }

            texture.Apply();
            renderer.material.mainTexture = texture;
        }


    }
}