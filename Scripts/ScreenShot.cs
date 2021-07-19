using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    public RawImage RawImage;
    public GameObject CamScreen;
    public GameObject Upper;
    public GameObject SprayCan;
    public GameObject RedCursol;
    WebCamTexture webCam;
    DateTime TodayNow;

    //private TextureReaderWrapper TextureReaderWrapper = null;
    // Start is called before the first frame update
    public void Awake()
    {
        // カメラ画像取得時に呼ばれるコールバック関数を定義
       
        
    }
    void Start()
    {
        // WebCamTextureのインスタンスを生成
        //webCam = new WebCamTexture();

        //RawImageのテクスチャにWebCamTextureのインスタンスを設定
        RawImage.texture = webCam;

        //90度回転
        Vector3 angles = RawImage.GetComponent<RectTransform>().eulerAngles;
        angles.z = -90;
        RawImage.GetComponent<RectTransform>().eulerAngles = angles;
        Vector2 size;
        size = RawImage.GetComponent<RectTransform>().sizeDelta;
        size.x = RawImage.GetComponent<RectTransform>().sizeDelta.y;
        size.y = RawImage.GetComponent<RectTransform>().sizeDelta.x;
        RawImage.GetComponent<RectTransform>().sizeDelta = size;


        //縦横のサイズを要求
        webCam.requestedWidth = 3024;
        webCam.requestedHeight = 4032;

        //カメラ表示開始
        webCam.Play();

        
    }

    // Update is called once per frame
    void Update()
    {
        TodayNow = DateTime.Now;
        //Debug.Log(TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString() + DateTime.Now.ToLongTimeString());//TodayNow.Year.ToString() + 
    }
    public void OnClickPlay()
    {
        // カメラを停止
        webCam.Play();
    }

    public void OnClickShot()
    {
        // カメラを停止
        webCam.Pause();
    }
    public void OnClickSave()
    {



        /*
        //テキストUIに年・月・日・秒を表示させる
        
        // インスタンス取得

        // Texture2Dを新規作成
        Texture2D texture = new Texture2D(webCam.width, webCam.height, TextureFormat.ARGB32, false);
        // カメラのピクセルデータを設定
        texture.SetPixels(webCam.GetPixels());
        // TextureをApply
        texture.Apply();
        */
        var texture = this.gameObject.GetComponent<TextureReaderWrapper>().FrameTexture;
        // Encode
        byte[] bin = texture.EncodeToJPG();
        // Encodeが終わったら削除
        Destroy(texture);  //Object.

        // ファイルを保存
#if UNITY_ANDROID
        //File.WriteAllBytes(Application.persistentDataPath + "/TodayNow.Year + TodayNow.Month + TodayNow.Day  + DateTime.Now.jpg", bin);
        NativeGallery.SaveImageToGallery(bin, "DCIM", TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString() + DateTime.Now.ToLongTimeString() + ".jpg");
#else
        File.WriteAllBytes(Application.persistentDataPath + "/test.jpg", bin);
#endif
    }
    public void DisplayCamScreen()
    {
        CamScreen.SetActive(true);
        Upper.GetComponent<RawImage>().color = new Color32(31, 31, 31,255);
        SprayCan.SetActive(false);
        RedCursol.SetActive(false);
    }
}
