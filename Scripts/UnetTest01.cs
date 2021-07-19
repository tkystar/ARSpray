using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UnetTest01 : NetworkBehaviour
{
    [SyncVar]
    int m_Count = 0;
    public GameObject count = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdCountUp();
        }
        //m_CountText.text = m_Count.ToString();
        Text ditance_text = count.GetComponent<Text>();
        ditance_text.text = "kyori"+ m_Count;//+D
    }

    [Command]
    void CmdCountUp()
    {
        m_Count++;
    }
}
