using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoitBtnClicked : MonoBehaviour
{
    public GameObject ColorComfirmObj;
    //public GameObject SpoitedColorApplicationBtn;
    //public GameObject BackFromSpoitedSceneBtn;
    public GameObject SpoitedScene;
    // Start is called before the first frame updateGetPixelColor
    void Start()
    {
        
        ColorComfirmObj.SetActive(false);
        //SpoitedColorApplicationBtn.SetActive(false);
        //BackFromSpoitedSceneBtn.SetActive(false);
        SpoitedScene.SetActive(false);
        GetComponent<OriginalColorSetting>().enabled = false;
        GetComponent<GetPixelColor>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spoitbtnclicked()
    {
        this.gameObject.SetActive(false);
        ColorComfirmObj.SetActive(true);
        //SpoitedColorApplicationBtn.SetActive(true);
        //BackFromSpoitedSceneBtn.SetActive(true);
        SpoitedScene.SetActive(true);
        GetComponent<OriginalColorSetting>().enabled = true;
        GetComponent<GetPixelColor>().enabled = true;
    }
    public void SpoitedColorApplicationBtnclicked()
    {
        this.gameObject.SetActive(true);
        ColorComfirmObj.SetActive(false);
        GetComponent<OriginalColorSetting>().enabled = false;
        GetComponent<GetPixelColor>().enabled = false;
        SpoitedScene.SetActive(false);
        //SpoitedColorApplicationBtn.SetActive(false);
        //BackFromSpoitedSceneBtn.SetActive(false);
    }
    public void BackFromSpoitedSceneBtnclicked()
    {
        this.gameObject.SetActive(true);
        ColorComfirmObj.SetActive(false);
        GetComponent<OriginalColorSetting>().enabled = false;
        GetComponent<GetPixelColor>().enabled = false;
        SpoitedScene.SetActive(false);
        //SpoitedColorApplicationBtn.SetActive(false);
        //BackFromSpoitedSceneBtn.SetActive(false);
    }
}
