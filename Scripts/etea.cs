using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class etea : MonoBehaviour
{
    public GameObject aaa;
    // Start is called before the first frame update
    void Start()
    {
        aaa.GetComponent<RawImage>().color = new Color32(31, 31, 31, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
