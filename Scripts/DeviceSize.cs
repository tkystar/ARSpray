using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceSize : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Text tex = text.GetComponent<Text>();
        tex.text = "Width:" + Screen.currentResolution.width +
            " Height:" + Screen.currentResolution.height +
            " Refresh Rate:" + Screen.currentResolution.refreshRate;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Width:" + Screen.currentResolution.width +
            " Height:" + Screen.currentResolution.height +
            " Refresh Rate:" + Screen.currentResolution.refreshRate);
    }
}
