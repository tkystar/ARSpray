using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnAniPlay : MonoBehaviour
{
    private Animation Btnanim;
    // Start is called before the first frame update
    void Start()
    {
        Btnanim = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    public void SprayBtnDown()
    {
        Btnanim.Play("SpBtnDown");
    }
    public void SprayBtnUp()
    {
        Btnanim.Play("SpBtnUp");
    }
}
