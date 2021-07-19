using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKBtn : MonoBehaviour
{
    public GameObject colorbtn;
    public GameObject colorpad;
    public GameObject spraybtn;
    public GameObject Okbtn;
    public GameObject Backbtn;
    public GameObject spraycan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OkBtn()
    {
        colorbtn.gameObject.SetActive(true);
        spraybtn.gameObject.SetActive(true);
        spraycan.gameObject.SetActive(true);
        Okbtn.gameObject.SetActive(false);
        Backbtn.gameObject.SetActive(false);
    }
}
