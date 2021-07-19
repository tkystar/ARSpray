using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BtnColorChange : MonoBehaviour
{
    public Text createroom;
    public Text enterroom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createroomColorChange()
    {
        createroom.GetComponent<Text>().color = new Color(10, 10, 1);
    }
    public void enterroomColorChange()
    {
        enterroom.GetComponent<Text>().color = new Color(10, 10, 1);
    }
}
