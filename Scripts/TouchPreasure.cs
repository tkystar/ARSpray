using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPreasure : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kanou = null;
    public GameObject length = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchPressureSupported)
        {
            Text status_text = kanou.GetComponent<Text>();
            status_text.text = "yes";
        }

        if (Input.touches.Length > 0)
        {
            Text num_text = length.GetComponent<Text>();
            num_text.text = ""+ Input.touches[0].pressure;
            //強さをログで表示
            Debug.Log(Input.touches[0].pressure);
        }
    }
}
