
namespace GoogleARCore.Examples.CloudAnchors
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.Networking;
    using UnityEngine.UI;
    using GoogleARCore;
    using GoogleARCore.Examples.Common;
    using UnityEngine.Networking.NetworkSystem;



    public class SharingTextureInfo : MonoBehaviour
    {
                    
        private Texture2D drawTexture;       
        public ParticleSystem particle;                     
        bool startspray = false;
        bool stopspray = false;
        bool alphabool = false;
        public Color pickedcolor;
        public GameObject ColorPicker;
        public GameObject cameraScreen;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void StartSpray()
        {
            startspray = true;
            stopspray = false;
            particle.Play(true);
            audioSource.Play();

        }
        public void StopSpray()
        {
            stopspray = true;
            startspray = false;
            particle.Stop(true);
            audioSource.Stop();
            alphabool = false;          ///切替タイミングは後で設定
        }
        public Color alphacolor= new Color(0, 0, 0, 0);
        public void AlphaBtn()
        {
            alphabool = true;
            cameraScreen.SetActive(false);
        }
        
              
        public void ResetCanvas()              //resetボタン作る.reset後は透明になるように設定する 未設定
        {
            /*
            Color[] pixels = new Color[drawTexture.width * drawTexture.height];

            for (int y = 0; y < drawTexture.height; y++)
            {
                for (int x = 0; x < drawTexture.width; x++)
                {
                    pixels[drawTexture.width * y + x] = Color.white;
                }
            }

            drawTexture.SetPixels(pixels);
            drawTexture.Apply(); // Applyしないと、変更が反映されない
            */
            GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().ResetCanvas();
            cameraScreen.SetActive(false);
        }
       
        void Update()
        {

            if (startspray)
            {
                if (!alphabool)
                {
                    pickedcolor = ColorPicker.GetComponent<Image>().color;
                    particle.gameObject.GetComponent<ParticleSystem>().startColor = pickedcolor;
                    GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().standard(pickedcolor);
                }
                else
                {

                    particle.gameObject.GetComponent<ParticleSystem>().startColor = alphacolor;
                    GameObject.Find("LocalPlayer").GetComponent<LocalPlayerController>().standard(alphacolor);

                }
            }

        }
            

    }



}



