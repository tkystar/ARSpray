using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justtexmap : MonoBehaviour
{
    private Renderer renderer;
    private Texture2D drawTexture;
    private Color[] textureBuffer;
    public GameObject asa;
    int r = 20;
    // Start is called before the first frame update
    void Start()
    {
        this.renderer = asa.gameObject.GetComponent<Renderer>();

        var bodyTexture = (Texture2D)this.renderer.material.mainTexture;
        var bodyPixels = bodyTexture.GetPixels();
        this.textureBuffer = new Color[bodyPixels.Length];
        bodyPixels.CopyTo(this.textureBuffer, 0);

        this.drawTexture = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
        this.drawTexture.filterMode = FilterMode.Bilinear;
        this.drawTexture.SetPixels(this.textureBuffer);
        this.drawTexture.Apply();
        this.renderer.material.mainTexture = this.drawTexture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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

                            //alpha = GetComponent<MeshRenderer>().material.color.a;
                        }
                    }
                }

            }


           
        }
        // テクスチャを適用
        this.drawTexture.SetPixels(this.textureBuffer);
        this.drawTexture.Apply();
        this.renderer.material.mainTexture = this.drawTexture;
    }
}
