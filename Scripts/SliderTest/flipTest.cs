using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flipTest : MonoBehaviour
{
    bool sceneTransutuin = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().material.SetFloat("_Flip", 1.0f);
    }

    // Update is called once per frame
    public void SliderScene()
    {
        sceneTransutuin = true;
    }
    void Update()
    {
        if (sceneTransutuin)
        {
            float flipValue = this.GetComponent<Image>().material.GetFloat("_Flip");

            if (flipValue > -1.0f)
            {
                flipValue -= 1f * Time.deltaTime;
                this.GetComponent<Image>().material.SetFloat("_Flip", flipValue);
            }
        }
        
    }
}