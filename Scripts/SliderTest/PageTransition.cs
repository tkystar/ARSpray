using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PageTransition : MonoBehaviour
{
    public Image m_DrawTex;
    public GameObject image;
    public bool DontDestroyEnabled = true;

    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }
    public void Botton()
    {
        StartCoroutine("Capture");
    }

    IEnumerator Capture()
    {
        //ReadPicxelsがこの後でないと使えないので必ず書く
        yield return new WaitForEndOfFrame();

        //スクリーンの大きさのSpriteを作る
        var texture = new Texture2D(Screen.width, Screen.height);

        //スクリーンを取得する
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //適応する
        texture.Apply();

        //取得した画像をSpriteに入るように変換する
        byte[] pngdata = texture.EncodeToPNG();
        texture.LoadImage(pngdata);

        //先ほど作ったSpriteに画像をいれる
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log("c");

        //Spriteを使用するオブジェクトに指定する
        //     今回はUIのImage
        m_DrawTex.GetComponent<Image>().sprite = sprite;

        // サイズ変更
        m_DrawTex.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);

        //imageをアクティブにする
        image.SetActive(true);

        nextScene();
    }
    public void nextScene()
    {
        //任意のシーンへ移動する
        SceneManager.LoadScene("シーンの名前");

        //destroyできるようにする
        DontDestroyEnabled = false;
    }
}
