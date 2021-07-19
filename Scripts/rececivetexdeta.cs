using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rececivetexdeta : MonoBehaviour
{
    public GameObject asa; //生成されるobj
    public GameObject receiveobj;
    GameObject at;
    private Renderer renderer;
    public Color[] textureBufferA;
    private Texture2D drawTextureA;
    private Texture2D bodyTexture;

    // Start is called before the first frame update
    void define()
    {
        this.renderer = receiveobj.gameObject.GetComponent<Renderer>();

        var bodyTexture = (Texture2D)this.renderer.material.mainTexture;
        var bodyPixels = bodyTexture.GetPixels();
        this.textureBufferA = new Color[bodyPixels.Length];
        bodyPixels.CopyTo(this.textureBufferA, 0);

        this.drawTextureA = new Texture2D(bodyTexture.width, bodyTexture.height, TextureFormat.RGBA32, false);
        this.drawTextureA.filterMode = FilterMode.Bilinear;
        this.drawTextureA.SetPixels(this.textureBufferA);
        this.drawTextureA.Apply();
        //this.renderer.material.mainTexture = this.drawTextureA;
    }
    public GameObject plane;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            plane = Instantiate(asa, new Vector3(0, 0, 0), Quaternion.identity);
            define();
            plane.name = "hoge1";
        }
    }
    public void applytex(byte[] bytearray)
    {
        var colorArray = new Color[bytearray.Length / 4];
        for (var i = 0; i < bytearray.Length; i += 4)
        {
            var color = new Color32(bytearray[i + 0], bytearray[i + 1], bytearray[i + 2], bytearray[i + 3]);
            colorArray[i / 4] = color;
        }
        this.drawTextureA.SetPixels(colorArray);
        this.drawTextureA.Apply();
        this.renderer.material.mainTexture = this.drawTextureA;




        //this.drawTexture.LoadImage(bytearray);       
        //this.drawTexture.Apply();   
        //receiveobj.gameObject.GetComponent<Renderer>().material.mainTexture = this.drawTexture;//setpixels関数による変更を適用           
        //this.renderer.material.mainTexture = this.drawTexture;
        /*
        this.drawTexture.SetPixels(colorarray);
        this.drawTexture.Apply();
        this.renderer.material.mainTexture = this.drawTexture;
        */
    }
    public void applytexx(Color color)
    {
        this.renderer.material.color = color;
    }
}
