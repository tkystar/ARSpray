namespace GoogleARCore.Examples.Common
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using GoogleARCore;

    public class trackingBtn : MonoBehaviour
    {
        public GameObject Anounce = null;
        // Start is called before the first frame update
        public void trackingbtndown()
        {
            GetComponent<DetectedPlaneGenerator>().enabled = true;
            Text button_text = Anounce.GetComponent<Text>();
            button_text.text = "Detect Wall";
        }
    }
}