using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeCount : MonoBehaviour
{
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public static int Shakecount;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound=this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        preAcceleration = Acceleration;
        Acceleration = Input.acceleration;
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        if (DotProduct < 0)
        {       
            sound.Play();
        }        
    }
   
}
