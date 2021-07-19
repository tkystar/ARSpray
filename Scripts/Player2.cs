using UnityEngine;
using UnityEngine.Networking; // ←NetworkBehaviour使うのに必要




    public class Player2 : NetworkBehaviour // ←NetworkBehaviourを継承
    {
        // SyncVar属性を付けた変数は各クライアント間で同期される
        //public GameObject SpherePrefab;
        [SyncVar]
        int m_Count = 0;
        //[SyncVar]
        //Color cubecolor;

        TextMesh m_CountText;

        void Start()
        {
            // 自分の子からTextMeshコンポーネントを取得する
            m_CountText = this.gameObject.GetComponentInChildren<TextMesh>();

        }

        void Update()
        {
            // ローカルプレイヤーのみ（他人のプレイヤーでは、やらない）
            if (isLocalPlayer)
            {

                // スペースキー押下でカウントアップ
                if (Input.GetMouseButtonDown(0))
                {
                    int x = Random.Range(1, 3);
                    int y = Random.Range(1, 3);
                    CmdCountUp(x,y);
                    //CmdColor();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {

                    //CmdColor();
                }
            }
            // テキストを更新する
            m_CountText.text = m_Count.ToString();
            //SpherePrefab.gameObject.GetComponent<Renderer>().material.color = cubecolor;
        }

        // カウントアップ処理はサーバーで行う
        [Command]
        void CmdCountUp(int a, int b)
        {

            m_Count = a + b;
        }
        [Command]
        void CmdColor()
        {

            //cubecolor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
        [Command]
        public void Cmdspawncube()
        {

            //var starObject = Instantiate(SpherePrefab);
            Debug.Log("#");

            //NetworkServer.Spawn(starObject);
        }
    }
