using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXUIManager : MonoBehaviour
{
    public GameObject EXUI;
    public GameObject EXUI01;
    public GameObject EXUI02;
    public GameObject SprayScene;
    public GameObject Host;
    public GameObject Client;
    public GameObject BeforeDrawing1;
    public GameObject BeforeDrawing2;
    public GameObject BeforeDrawing3;
    float aime;
    // Start is called before the first frame update
    public void OkBtn01Clicked()
    {
        Host.SetActive(false);
        Client.SetActive(false);
    }
    public void NextBtnClicked()
    {
        EXUI01.SetActive(false);
        EXUI02.SetActive(true);
    }
    public void CreateClicked()
    {
        Host.SetActive(true);
        SprayScene.SetActive(false);
    }
    public void EnterClicked()
    {
        Client.SetActive(true);
        SprayScene.SetActive(false);
    }
    public void onetotwo()
    {
        BeforeDrawing1.SetActive(false);
        BeforeDrawing2.SetActive(true);
    }
    public void twotothree()
    {
        BeforeDrawing2.SetActive(false);
        BeforeDrawing3.SetActive(true);
    }
    public void threetodelete()
    {
        BeforeDrawing3.SetActive(false);

    }
}
