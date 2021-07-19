using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public static class MyMsgg
{
    public const short Reset = MsgType.Highest + 1;
    public const short DrawPoint = MsgType.Highest + 2;
}

class DrawPointMessage : MessageBase
{
    public int x;
    public int y;
}

public class OekakiChat : MonoBehaviour
{
    public GameObject planeprehab;
    const int Port = 7777;           //PCの窓の番号。ネットワークで送受信される情報がPCに入るときや出る時に使う窓の番号
    NetworkClient client;
    public Texture2D texture;
    bool a;
    void Start()
    {
        // テクスチャーを生成
        texture = new Texture2D(256, 256);
        // 補間無し
        texture.filterMode = FilterMode.Bilinear;
        // 白で塗りつぶし
        //ResetCanvas();

        // RawImageにテクスチャーを設定
        GetComponent<RawImage>().texture = texture;
        //planeprehab.GetComponent<Renderer>().material.mainTexture = texture;
        a = false;
    }
    public void clickone()
    {
        NetworkServer.Listen(Port);
        NetworkServer.RegisterHandler(MyMsgg.Reset, OnServerResetReceived);
        NetworkServer.RegisterHandler(MyMsgg.DrawPoint, OnServerDrawPointReceived);
        
                                                                                         //drawpointタイプのmessageを受け取った時に発動する関数はOnServerDrawPointReceived
    }
    public void clicktwo()
    {
        client = new NetworkClient();
        client.Connect("192.168.11.3", Port);                      ///127.0.0.1は自分自身（ローカルホスト）
        client.RegisterHandler(MyMsgg.Reset, OnClientResetReceived);
        client.RegisterHandler(MyMsgg.DrawPoint, OnClientDrawPointReceived);
        a = true;
    }

    void Update()
    {
        
        /*
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log("GG");
            return;
        }*/
        /*
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            return;
        }*/

        // Rキーでリセット
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCanvas();

            // リセットしたことをサーバーへ通知
            client.Send(MyMsgg.Reset, new EmptyMessage());
        }

        // マウス左ボタンで描画
        
        if (Input.GetMouseButton(0)&&a==true)
        {
            

            Debug.Log("DD");
                Vector2 screenPos = GetMousePosInScreenPoint();
                DrawPoint((int)screenPos.x, (int)screenPos.y, Color.blue);   //ここで素でに描画

                // 点を描画したことをサーバーへ通知
                DrawPointMessage m = new DrawPointMessage();
                m.x = (int)screenPos.x;
                m.y = (int)screenPos.y;
                client.Send(MyMsgg.DrawPoint, m);
            
            
        }

        // 1キーでサーバー起動
        if (Input.GetKeyDown("1"))
        {
            NetworkServer.Listen(Port);
            NetworkServer.RegisterHandler(MyMsgg.Reset, OnServerResetReceived);
            NetworkServer.RegisterHandler(MyMsgg.DrawPoint, OnServerDrawPointReceived);               //drawpointタイプのmessageを受け取った時に発動する関数はOnServerDrawPointReceived
        }

        // 2キーでクライアント起動
        if (Input.GetKeyDown("2"))
        {
            client = new NetworkClient();
            client.Connect("127.0.0.1", Port);                      ///127.0.0.1は自分自身（ローカルホスト）
            client.RegisterHandler(MyMsgg.Reset, OnClientResetReceived);
            client.RegisterHandler(MyMsgg.DrawPoint, OnClientDrawPointReceived);
        }
    }

    // マウスの場所をスクリーン座標（というかテクスチャー上での座標）で取得する
    Vector2 GetMousePosInScreenPoint()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = new Vector2(mousePos.x / Screen.width * texture.width, mousePos.y / Screen.height * texture.height);

        screenPos.x = Mathf.Clamp(screenPos.x, 0, texture.width - 1);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, texture.height - 1);

        return screenPos;
    }

    // リセット
    void ResetCanvas()
    {
        Color[] pixels = new Color[texture.width * texture.height];

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                pixels[texture.width * y + x] = Color.white;
            }
        }

        texture.SetPixels(pixels);
        texture.Apply(); // Applyしないと、変更が反映されない
    }
    int xx;
    int yy;
    // 指定した点を塗る
    void DrawPoint(int x, int y, Color color)
    {
        for (int i = 0; i <= 8; i++)
        {

            for (int theta = 0; theta <= 360; theta +=1)    // Random.Range(5, 10)
            {
                xx = (int)(x + i * Mathf.Cos(theta));
                yy = (int)(y + i * Mathf.Sin(theta));
                texture.SetPixel(xx, yy, color);

            }
        }
        
        texture.Apply();
    }

    // サーバーがResetメッセージを受信した際のハンドラ
    void OnServerResetReceived(NetworkMessage message)
    {
        // リセットしたことを全クライアントへ通知
        NetworkServer.SendToAll(MyMsgg.Reset, new EmptyMessage());
    }

    // サーバーがDrawPointメッセージを受信した際のハンドラ
    void OnServerDrawPointReceived(NetworkMessage message)
    {
        // 点を描画したことを全クライアントへ通知
        NetworkServer.SendToAll(MyMsgg.DrawPoint, message.ReadMessage<DrawPointMessage>());
    }

    // クライアントがResetメッセージを受信した際のハンドラ
    void OnClientResetReceived(NetworkMessage message)
    {
        ResetCanvas();
    }

    // クライアントがDrawPointメッセージを受信した際のハンドラ
    void OnClientDrawPointReceived(NetworkMessage message)
    {
        DrawPointMessage m = message.ReadMessage<DrawPointMessage>();
        DrawPoint(m.x, m.y, Color.blue);
    }
}