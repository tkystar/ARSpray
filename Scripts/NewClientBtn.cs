using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClientBtn : MonoBehaviour
{
    public GameObject spraycanvas;
    public GameObject SprayPrefab;
    public GameObject Image;

    // Start is called before the first frame update
    void Start()
    {
        Image.SetActive(false);
        this.gameObject.SetActive(false);
        spraycanvas.SetActive(false);
        SprayPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OKBtnClicked()
    {
        spraycanvas.SetActive(true);
        SprayPrefab.SetActive(true);
        Image.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void EnterRoom()
    {
        Image.SetActive(true);
        this.gameObject.SetActive(true);
        
    }
}
