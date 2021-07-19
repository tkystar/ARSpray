using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class ScreenShot02 : MonoBehaviour
{
    Camera cam;
    //GameObject canvas;
    //GameObject targetImage;
    string screenShotPath;
    string timeStamp;
    DateTime TodayNow;
    public GameObject CamScreen;
    public GameObject Upper;
    public GameObject SprayCan;
    public GameObject RedCursol;

    void Awake()
    {
        cam = GameObject.Find("First Person Camera").GetComponent<Camera>();
        //canvas = GameObject.Find("Canvas");
        //targetImage = GameObject.Find("RawImage");
    }
    /*
    private string GetScreenShotPath()
    {
        string path = "";
        // �v���W�F�N�g�t�@�C�������ɍ쐬
        path = timeStamp + ".png";
        //		path = Application.persistentDataPath+timeStamp + ".png";
        return path;
    }*/

    // UI�����������ꍇ��canvas���A�N�e�B�u�ɂ���
    private void UIStateChange()
    {
        //canvas.SetActive(!canvas.activeSelf);
    }

    private IEnumerator CreateScreenShot()
    {
        //UIStateChange();
        DateTime date = DateTime.Now;
        timeStamp = date.ToString("yyyy-MM-dd-HH-mm-ss-fff");
        // �����_�����O�����܂őҋ@
        yield return new WaitForEndOfFrame();

        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.width*4/3, 24);///Screen.height
       cam.targetTexture = renderTexture;

        Texture2D texture = new Texture2D(cam.targetTexture.width, cam.targetTexture.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 295, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        texture.Apply();

        // �ۑ�����摜�̃T�C�Y��ς���Ȃ�ResizeTexture()�����s
        //		texture = ResizeTexture(texture,320,240);

        byte[] pngData = texture.EncodeToPNG();
        NativeGallery.SaveImageToGallery(pngData, "DCIM", TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString() + DateTime.Now.ToLongTimeString() + ".jpg");
        /*
        screenShotPath = GetScreenShotPath();

        // �t�@�C���Ƃ��ĕۑ�����Ȃ�File.WriteAllBytes()�����s
        File.WriteAllBytes(screenShotPath, pngData);

        cam.targetTexture = null;

        Debug.Log("Done!");
        UIStateChange();
        */
    }
    /*
    Texture2D ResizeTexture(Texture2D src, int dst_w, int dst_h)
    {
        Texture2D dst = new Texture2D(dst_w, dst_h, src.format, false);

        float inv_w = 1f / dst_w;
        float inv_h = 1f / dst_h;

        for (int y = 0; y < dst_h; ++y)
        {
            for (int x = 0; x < dst_w; ++x)
            {
                dst.SetPixel(x, y, src.GetPixelBilinear((float)x * inv_w, (float)y * inv_h));
            }
        }
        return dst;
    }*/

    public void ClickShootButton()
    {
        StartCoroutine(CreateScreenShot());
    }
    /*
    public void ShowSSImage()
    {
        if (!String.IsNullOrEmpty(screenShotPath))
        {
            byte[] image = File.ReadAllBytes(screenShotPath);

            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(image);

            // NGUI �� UITexture �ɕ\��
           // RawImage target = targetImage.GetComponent<RawImage>();
           // target.texture = tex;
        }
    }*/
    void Update()
    {
        TodayNow = DateTime.Now;
    }

    public void DisplayCamScreen()
    {
        CamScreen.SetActive(true);
        Upper.GetComponent<RawImage>().color = new Color32(31, 31, 31, 255);
        SprayCan.SetActive(false);
        RedCursol.SetActive(false);
    }
}

