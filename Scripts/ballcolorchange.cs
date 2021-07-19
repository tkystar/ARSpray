using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcolorchange : MonoBehaviour
{
    private Renderer Ballrenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        Ballrenderer= this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ballrenderer.material.color = Color.red;
        }
    }
}
