using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPrayIcon : MonoBehaviour
{
    public GameObject Can;
    public GameObject spraySceen;
    public GameObject CameraScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void sprayicon()
    {
        Can.SetActive(true);
        spraySceen.SetActive(true);
        CameraScene.SetActive(false);
    }
}
