using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasttest : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;


            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    //もしhitのタグが"Player"と一致していた場合．．．の処理内容
                    //Instantiate(cube, hit.point, Quaternion.identity, transform);
                    GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

                    // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
                    // foreachは配列の要素の数だけループします。
                    foreach (GameObject player in Players)
                    {
                        // 消す！
                        Destroy(player);
                    }
                    Instantiate(sphere, mousePosition,Quaternion.identity);
                }

            }
        }
    }
}
