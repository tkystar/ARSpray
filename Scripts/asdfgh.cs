using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asdfgh : MonoBehaviour
{

    private Renderer renderer;
    private Texture2D drawTexture;
    private Color[] textureBuffer;
    private int brushSize = 10;
    public GameObject drawableplane;
    //public Camera arcamera;
    bool startspray = false;
    bool stopspray = false;
    //about statustext
    //public GameObject drawingstatus = null;
    //public GameObject Buttonstatus = null; 
    //public GameObject  distance= null;

    // Start is called before the first frame update
    void Start()
    {
        this.renderer = drawableplane.gameObject.GetComponent<Renderer>();
        //this.renderer = drawableplane.gameObject.GetComponent<Renderer>();
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

    public void StrartSpray()
    {
        startspray = true;
        stopspray = false;



        Debug.Log("!");
    }
    public void StopSpray()
    {
        stopspray = true;
        startspray = false;

    }
    public void soundstart()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);
        if (startspray == true)
        {


            //Text button_text = Buttonstatus.GetComponent<Text>();
            //button_text.text = "buttondownnow";
            Ray ray = Camera.main.ScreenPointToRay(center);
            RaycastHit hit;
            //if (Physics.Raycast(arcamera.transform.position, transform.TransformDirection(Vector3.forward), out hit))
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                //Text status_text = drawingstatus.GetComponent<Text>();
                //status_text.text = "Drawing Now.....";
                Debug.Log("aaaa");
                var hitPoint = new Vector2(hit.textureCoord.x * drawTexture.width, hit.textureCoord.y * drawTexture.height);
                int d = (int)(hit.distance * 40);
                //Text ditance_text = distance.GetComponent<Text>();
                //ditance_text.text = ""+d;
                //int r = 30;
                if (d < 300)
                {
                    for (int i = 0; i <= d; i++)
                    {
                        Debug.Log("bbbb");
                        for (int theta = 0; theta <= 360; theta++)
                        {
                            int x = (int)(hitPoint.x + i * Mathf.Cos(theta));
                            int y = (int)(hitPoint.y + i * Mathf.Sin(theta));
                            if (x >= 0 && y >= 0)
                            {
                                this.textureBuffer.SetValue(Color.cyan, (int)x + drawTexture.width * (int)y);        //decide color
                                Debug.Log("cccc");
                                //alpha = GetComponent<MeshRenderer>().material.color.a;
                            }
                        }
                    }
                }
            }
            this.drawTexture.SetPixels(this.textureBuffer);
            this.drawTexture.Apply();
            this.renderer.material.mainTexture = this.drawTexture;
        }
        else
        {
            //Text button_text = Buttonstatus.GetComponent<Text>();
            ///button_text.text = "buttonupnow";
            //Text status_text = drawingstatus.GetComponent<Text>();
            //status_text.text = "Let's draw!";
        }


    }
}
