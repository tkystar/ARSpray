using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tekitou : MonoBehaviour
{
    public GameObject distance = null;
    public GameObject yesorno = null;
    // Start is called before the first frame update
    void Start()
    {
        Text ditance_text = distance.GetComponent<Text>();
        ditance_text.text = "kyori";//+D
        Text state_text = yesorno.GetComponent<Text>();
        state_text.text = "noooo";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
