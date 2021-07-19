using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DrawUNET : NetworkBehaviour
{
    //float alpha;
    //private Color color;
    
    private Renderer renderer;   
    private Texture2D drawTexture;
    [SyncVar]
    int pixelNum = 0;
    
    private Color[] textureBuffer;
    public GameObject asa;
    int r = 20;
    //public GameObject distance = null;
    //public GameObject drawingstatus = null;
    // Use this for initialization
    void Start()
    {
        Debug.Log("!!!!!!!!!!!!!");
        //GameObject[] cubes = GameObject.FindGameObjectsWithTag("Player");
        
        this.renderer = asa.gameObject.GetComponent<Renderer>();

        var bodyTexture = (Texture2D)this.renderer.sharedMaterial.mainTexture;
        
        var bodyPixels = bodyTexture.GetPixels();
        this.textureBuffer = new Color[bodyPixels.Length];
        bodyPixels.CopyTo(this.textureBuffer, 0);

        this.drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
        this.drawTexture.filterMode = FilterMode.Bilinear;
        this.drawTexture.SetPixels(this.textureBuffer);
        this.drawTexture.Apply();
        this.renderer.sharedMaterial.mainTexture = this.drawTexture;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
        if (Input.GetMouseButton(0))
        {

            Cmddrawunet();

            // テクスチャを適用
            this.drawTexture.SetPixels(this.textureBuffer); ///this.textureBuffer
            this.drawTexture.Apply();
            this.renderer.sharedMaterial.mainTexture = this.drawTexture;
        }
    }

    [Command]
    void Cmddrawunet()
    {
        // Screenのマウスの位置から空間に向けてレイ(光線)を放つ
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // 光線が何かのオブジェクトにヒットしたなら
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Player"))
        {



            //Text status_text = drawingstatus.GetComponent<Text>();
            //status_text.text = "Drawing Now.....";
            // UV値からテクスチャのどの部分にヒットしたのかを計算
            var hitPoint = new Vector2(hit.textureCoord.x * drawTexture.width, hit.textureCoord.y * drawTexture.height);
            int d = (int)(hit.distance * 40);
            //Text ditance_text = distance.GetComponent<Text>();
            //ditance_text.text = "kyoriha" + d;//+D
            //color = new Color(10, 50, 47, 10);
            // brushSize分のピクセルを塗りつぶす

            /*
            for (int x = (int)(hitPoint.x - r); x < hitPoint.x +r; x++)
            {
                //for (int y = (int)-Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x, 2)); y < Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x, 2)); y++)

                //float y = Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(hitPoint.x-x, 2));
                int y = (int)hitPoint.y;

                    if (x >= 0 && y >= 0)
                    {
                        this.textureBuffer.SetValue(Color.cyan, (int)x + drawTexture.width * (int)y);        //decide color

                        //alpha = GetComponent<MeshRenderer>().material.color.a;
                    }

            }*/
            for (int i = 0; i <= r; i++)
            {
                for (int theta = 0; theta <= 360; theta++)
                {
                    int x = (int)(hitPoint.x + i * Mathf.Cos(theta));
                    int y = (int)(hitPoint.y + i * Mathf.Sin(theta));
                    pixelNum = (int)x + drawTexture.width * (int)y;
                    if (x >= 0 && y >= 0)
                    {
                        this.textureBuffer.SetValue(Color.cyan, pixelNum);        //decide color

                        //alpha = GetComponent<MeshRenderer>().material.color.a;
                        Debug.Log("1");
                    }
                }
            }
        }
    }

}