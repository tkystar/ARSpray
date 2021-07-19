using UnityEngine;

public class GetColor : MonoBehaviour
{
    public Color color;
    private Texture2D tex = null;
    private Vector2 pos;
    void Start()
    {
        tex = new Texture2D(1, 1, TextureFormat.RGB24, false);
    }

    void OnPostRender()
    {
        if(Input.GetMouseButtonDown(0))
         pos = Input.mousePosition;
        tex.ReadPixels(new Rect(pos.x, pos.y, 1, 1), 0, 0);
        color = tex.GetPixel(0, 0);
    }
    private void Update()
    {
        OnPostRender();
    }
}
