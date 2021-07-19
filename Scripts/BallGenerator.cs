using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{

    public GameObject RedBallPrefab;
    private Vector3 clickPosition;
   

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tmp = GameObject.Find("First Person Camera").transform.position;
            clickPosition = Input.mousePosition;

            //今のままではクリックした場所(手前)にボールが落ちてしまうので奥の方向(Z軸側)にPrefabのインスタンスを作る位置をズラす
            clickPosition.z = 10f;

            GameObject RedBall = Instantiate(RedBallPrefab,tmp, RedBallPrefab.transform.rotation);

            RedBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 100));
        }

    }
}