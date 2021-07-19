using System.Collections.Generic;
using UnityEngine;

public class DrawingManager2 : MonoBehaviour
{

    DrawerBase drawer;
    DrawableBase[] drawables;
    //public GameObject DetectedPlanePrefab;
    public Material mat;
    public Camera FirstPersonCamera;
    // Use this for initialization
    void Start()
    {
        
        //GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.blue;
        /*GameObject planeObject =
                    Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
        planeObject.GetComponent<Renderer>().material = mat;
        planeObject.AddComponent<CanvasObject>();
        planeObject.AddComponent<Rotater>();
        */

    }

    // Update is called once per frame
    void Update()
    {
        drawer = FindObjectOfType<DrawerBase>();
        drawables = FindObjectsOfType<DrawableBase>();
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var ray = new Ray(FirstPersonCamera.transform.position, FirstPersonCamera.transform.forward);//メインカメラからマウスポジションへRayを飛ばしている
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            drawer.drawing = true;
            drawer.color = Color.blue;
            //drawer.color = Color.HSVToRGB((Time.time * 0.1f % 1f), 1f, 1f);
            drawer.transform.LookAt(hit.point);
        }

        // drawer.drawing = Input.GetMouseButton(0);


        foreach (var drawable in drawables)
            drawable.ClearGuid();

        drawer.Draw();
        drawer.DrawGuid();

        foreach (var drawable in drawables)
            drawable.Apply();



    }
    /*
    private void OnGUI()
    {
        var width = Screen.width * 0.2f;
        var height = Screen.height;
        var rect = new Rect(0, 0, width, height);

        GUI.backgroundColor = Color.gray;
        for (var i = 0; i < 1; i++)              //i<2からi<1に変えた
        {
            var co = (CanvasObject)drawables[i];
            rect.x = (Screen.width - width) * i;

            GUILayout.BeginArea(rect, (GUIStyle)"box");
            GUILayout.Label(co.name);
            GUILayout.Label("position texture");
            GUILayout.Label(co.posTex, GUILayout.Width(width), GUILayout.Height(width));
            GUILayout.Label("canvas texture");
            GUILayout.Label(co.drawingTex, GUILayout.Width(width), GUILayout.Height(width));
            GUILayout.EndArea();
        }
    }*/
}
