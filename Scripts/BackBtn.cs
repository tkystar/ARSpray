using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtn : MonoBehaviour
{
    public GameObject colorbtn;
    public GameObject spraybtn;
    public GameObject Okbtn;
    public GameObject Backbtn;
    public GameObject spraycan;
    public GameObject kiri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BackBtnDown()
    {
        colorbtn.gameObject.SetActive(true);
        spraybtn.gameObject.SetActive(true);
        spraycan.gameObject.SetActive(true);
        Okbtn.gameObject.SetActive(false);
        Backbtn.gameObject.SetActive(false);
        //spraycan.gameObject.GetComponent<Renderer>().material.color=beforecolor;
        //kiri.gameObject.GetComponent<ParticleSystem>().startColor = beforecolor;
    }
}
