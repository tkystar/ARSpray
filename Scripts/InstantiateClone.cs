using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateClone : MonoBehaviour
{
    public GameObject prehab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prehab, new Vector3(0, 0, 2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
