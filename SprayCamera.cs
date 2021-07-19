using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayCamera : MonoBehaviour
{
    Texture2D capture_display;
    string fileName = "screenshot\\image.bin";
    System.IO.BinaryWriter writer;
    byte[] yxrgb;
    int ary_size;

    // Start is called before the first frame update
    void Start()
    {
        capture_display = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        writer = new System.IO.BinaryWriter(new System.IO.FileStream(fileName, System.IO.FileMode.Append));
        ary_size = Screen.width * Screen.height * 3;
        yxrgb = new byte[ary_size];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
