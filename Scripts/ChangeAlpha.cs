using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{

    float toumeido = 0;
    [SerializeField] float toumeiTime;
    [SerializeField] float modoruTime;
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        toumeiTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            modoruTime = 0;
            toumeiTime += Time.deltaTime;
            toumeido = toumeiTime * 0.001f;
            Debug.Log(toumeiTime);
            mr = GetComponent<MeshRenderer>();
            if (mr.material.color.a >= -0.25f)
            {
                mr.material.color = mr.material.color - new Color(0, 0, 0, toumeido);
            }
        }
        else if(!Input.GetMouseButton(0)&&toumeido !=1)
        {
            toumeiTime = 0;
            modoruTime += Time.deltaTime;
            toumeido = modoruTime * 0.001f;
            if (mr.material.color.a <= 1.0f)
            {
                mr.material.color = mr.material.color + new Color(0, 0, 0, toumeido);
            }
        }

    }
}
