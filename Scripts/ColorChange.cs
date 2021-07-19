using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = mr.material.color - new Color32(160, 200, 100, 205);
    }
}