using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{
    public Camera mainCam;
    public Slider slider;
    Slider ColorSlider;
    public Color pink= new Color(254, 49, 98);
    public Color green = new Color(0, 193, 100);
    // Start is called before the first frame update
    void Start()
    {
        ColorSlider=slider.GetComponent<Slider>();
        //mainCam.backgroundColor = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (ColorSlider.value == 0)
            {
            mainCam.backgroundColor = green;
            Debug.Log("!");
            }
            if (ColorSlider.value == 1)
            {
            mainCam.backgroundColor = pink;
            Debug.Log("!?");
        }

        
        
    }
    public void SliderClicked()
    {



        

        if (ColorSlider.value == 0)
        {
            mainCam.backgroundColor = green;
        }
        else if(ColorSlider.value == 1)
        {
            mainCam.backgroundColor = pink;
        }
        //Camera.main.backgroundColor = green;


    }
}
