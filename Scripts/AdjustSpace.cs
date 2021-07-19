using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustSpace : MonoBehaviour
{
    RectTransform tra;
    // Start is called before the first frame update
    void Start()
    {
        tra=this.gameObject.GetComponent<RectTransform>();
        tra.sizeDelta = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height - (Screen.currentResolution.width*4/3+100));
        tra.anchoredPosition = new Vector2 (0,(Screen.currentResolution.height - (Screen.currentResolution.width * 4 / 3 + 100)) / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
