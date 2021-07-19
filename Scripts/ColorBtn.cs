using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBtn : MonoBehaviour
{
    public GameObject colorbtn;
    public GameObject spraybtn;
    //public GameObject Spoitbtn;
    public GameObject Okbtn;
    public GameObject Backbtn;
    public GameObject spraycan;
    public Color beforecolor;
    public GameObject kiri;

    // Start is called before the first frame update
    void Start()
    {
        colorbtn.gameObject.SetActive(false);
        Okbtn.gameObject.SetActive(false);
        Backbtn.gameObject.SetActive(false);
        //Spoitbtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ColorBtnDown()
    {
        //Spoitbtn.gameObject.SetActive(true);
        colorbtn.gameObject.SetActive(true);
        spraybtn.gameObject.SetActive(false);
        spraycan.gameObject.SetActive(false);
        Okbtn.gameObject.SetActive(true);
        Backbtn.gameObject.SetActive(true);
        beforecolor = spraycan.gameObject.GetComponent<Renderer>().material.color;
    }
    public void OkBtn()
    {
        colorbtn.gameObject.SetActive(false);
        spraybtn.gameObject.SetActive(true);
        spraycan.gameObject.SetActive(true);
        Okbtn.gameObject.SetActive(false);
        Backbtn.gameObject.SetActive(false);
        //Spoitbtn.gameObject.SetActive(false);
    }
    public void BackBtnDown()
    {
        colorbtn.gameObject.SetActive(false);
        spraybtn.gameObject.SetActive(true);
        spraycan.gameObject.SetActive(true);
        Okbtn.gameObject.SetActive(false);
        Backbtn.gameObject.SetActive(false);
        //Spoitbtn.gameObject.SetActive(false);

    }
}
