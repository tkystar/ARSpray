using UnityEngine;
using UniRx;
using UniRx.Triggers;
using CustomInput; //自分で定義したやつ
using System.Collections;

public class GetPixelColor : MonoBehaviour
{
    Coroutine runCoroutine;
    Texture2D screenTex;

    readonly public ColorReactiveProperty touchPosColorProperty = new ColorReactiveProperty();

    void Start()
    {
        screenTex = new Texture2D(1, 1, TextureFormat.RGB24, false);

        this.UpdateAsObservable()                                     //Update()をストリームに変換する
            .Where(_ => SimpleInput.GetTouchDown())
            .Subscribe(_ =>
            {
                if (runCoroutine == null)
                {
                    runCoroutine = StartCoroutine(GetColorTouchPos());
                }
            })
            .AddTo(this);
    }

    IEnumerator GetColorTouchPos()        //コルーチン
    {
        yield return new WaitForEndOfFrame();
        Vector2 touchPos = SimpleInput.GetTouchDownPos();
        if (touchPos != Vector2.zero)
        {
            screenTex.ReadPixels(new Rect(touchPos.x, touchPos.y, 1, 1), 0, 0);
            touchPosColorProperty.Value = screenTex.GetPixel(0, 0);
            Debug.Log(touchPosColorProperty.Value);
        }
        

        runCoroutine = null;
    }
}