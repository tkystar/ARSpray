using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textest01 : MonoBehaviour
{
    public GameObject a;
    private Texture2D tex;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        tex = (Texture2D)this.gameObject.GetComponent<Renderer>().material.mainTexture;
        a.gameObject.GetComponent<Renderer>().material.mainTexture=tex;
    }
    public void test()
    {

    }
}
