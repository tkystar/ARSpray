using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange01 : MonoBehaviour
{
    public GameObject colorchangeobj;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer=colorchangeobj.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            renderer.material.color = Color.blue;
        }
        
    }
}
