using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tests : MonoBehaviour
{
    public GameObject Anounce = null;
    // Start is called before the first frame update
    public void Down()
    {
        Text button_text = Anounce.GetComponent<Text>();
        button_text.text = "DOWN";
    }
    public void Up()
    {
        Text button_text = Anounce.GetComponent<Text>();
        button_text.text = "UP";
    }
}
