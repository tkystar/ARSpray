
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class senddrawcontent : MonoBehaviour
{
    //float alpha;
    //private Color color;
    //[SyncVar]
    //int pixelnum=0;
    //[SyncVar]
    //Color color=new Color(10,10,10);
    /*
    [SyncVar]
    Vector2 hitPoint;
    */
    private Renderer renderer;
    private Texture2D drawTexture;
    private Texture2D drawTextureA;
    private Color[] textureBuffer;
    Color[] textureBufferAA;
    public GameObject asa;
    int r = 20;
    //public GameObject distance = null;
    //public GameObject drawingstatus = null;
    // Use this for initialization
    bool sendtexture = false;

    bool oncetexdata = false;
    GameObject planee;
    void Start()
    {

        //GameObject[] cubes = GameObject.FindGameObjectsWithTag("Player");


        //textureBufferAA=GetComponent<rececivetexdeta>().textureBufferA;

        
    }
    void CompleteInstantiata()
    {
        this.renderer = planee.gameObject.GetComponent<Renderer>();

        var bodyTexture = (Texture2D)this.renderer.material.mainTexture;
        var bodyPixels = bodyTexture.GetPixels();
        this.textureBuffer = new Color[bodyPixels.Length];
        bodyPixels.CopyTo(this.textureBuffer, 0);

        this.drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
        this.drawTextureA = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
        this.drawTexture.filterMode = FilterMode.Bilinear;
        this.drawTexture.SetPixels(this.textureBuffer);
        this.drawTexture.Apply();
        this.renderer.material.mainTexture = this.drawTexture;
        Debug.Log("!");
        oncetexdata = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(oncetexdata == false)
        {
            planee = GameObject.Find("hoge1");
        }
        

        if (planee != null&& oncetexdata==false)
        {
            CompleteInstantiata();
            Debug.Log("!!");
            return;
        }
        

        //Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
        if (Input.GetMouseButton(0))
        {
            textureBufferAA = GetComponent<rececivetexdeta>().textureBufferA;
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



                for (int i = 0; i <= r; i++)
                {
                    for (int theta = 0; theta <= 360; theta++)
                    {

                        int x = (int)(hitPoint.x + i * Mathf.Cos(theta));
                        int y = (int)(hitPoint.y + i * Mathf.Sin(theta));


                        if (x >= 0 && y >= 0)
                        {
                            //this.textureBuffer.SetValue(Color.cyan, (int)x + drawTexture.width * (int)y);        //decide color
                            this.textureBuffer.SetValue(Color.cyan, (int)x + drawTexture.width * (int)y);
                            textureBufferAA.SetValue(Color.cyan, (int)x + drawTexture.width * (int)y);
                            //alpha = GetComponent<MeshRenderer>().material.color.a;
                        }
                    }
                }

            }


            // テクスチャを適用
            this.drawTexture.SetPixels(this.textureBuffer);
            this.drawTexture.Apply();
            this.renderer.material.mainTexture = this.drawTexture;

            drawTextureA.SetPixels(textureBufferAA);
        }
        
        
    }
    public Color color=Color.green;
    public byte[] Bytes;
    public void sendtex()
    {
        Bytes = drawTexture.GetRawTextureData();

        //this.GetComponent<rececivetexdeta>().applytex(Bytes);
        GameObject.Find("GameObject").GetComponent<rececivetexdeta>().applytex(Bytes);
        //this.GetComponent<rececivetexdeta>().applytexx(color);

        Debug.Log("true");

        return;
        
        
    }
    public void sendtexup()
    {
        
    }

}