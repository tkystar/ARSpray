using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OriginalColorSetting : MonoBehaviour
{
    //public ColorSelector colorselector;
    public GameObject changecolorobj;
    public GameObject SprayCan;
    public GameObject SprayParticle;
    GetPixelColor getpixelcolor;
    MeshRenderer renderer;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        renderer = this.gameObject.GetComponent<MeshRenderer>();       
        getpixelcolor =changecolorobj.GetComponent<GetPixelColor>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.GetComponent<Renderer>().material.color = colorselector.finalColor;
        if (Input.GetMouseButton(0))
        {

            // Rayを発射！
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            // Rayで何もヒットしなかったら画面クリックと考える
            if (!hit2d)
            {
                renderer.material.color = getpixelcolor.touchPosColorProperty.Value;
            }

        }
        
        
    }
    public void SprayColorSet()
    {
        getpixelcolor = changecolorobj.GetComponent<GetPixelColor>();
        SprayCan.GetComponent<MeshRenderer>().material.color= getpixelcolor.touchPosColorProperty.Value;
        SprayParticle.gameObject.GetComponent<ParticleSystem>().startColor = getpixelcolor.touchPosColorProperty.Value;
    }
}
