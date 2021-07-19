using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
