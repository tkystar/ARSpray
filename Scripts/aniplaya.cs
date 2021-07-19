using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniplaya : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    
    public void DownV()
    {
        anim.Play("cubeani");
    }
    public void UpV()
    {
        anim.Play("Down");
    }
}
