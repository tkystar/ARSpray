using UnityEngine;
using UniRx;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GetPixelColor getPixelColor;


    MeshRenderer thisObjMeshRenderer;

    void Start()
    {
        thisObjMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();

        getPixelColor
            .touchPosColorProperty
            .SkipLatestValueOnSubscribe()
            .Subscribe(_ =>
            {
                thisObjMeshRenderer.material.color = getPixelColor.touchPosColorProperty.Value;
            })
            .AddTo(this);
    }
}