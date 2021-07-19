using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjusttransparency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color = this.gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.0f;
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
