using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine.EventSystems;

public class DrawingManager : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public GameObject spray;
     DrawerBase drawer;
    DrawableBase[] drawables;

    // Use this for initialization
    void Start()
    {
        drawer = FindObjectOfType<DrawerBase>();
        drawables = FindObjectsOfType<DrawableBase>();
        

    }

    // Update is called once per frame
    void Update()
    {
    
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //var ray = new Ray(spray.transform.position, spray.transform.forward);
        //ここから
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            drawer.drawing = true;
            drawer.color = Color.blue;
            drawer.transform.LookAt(hit.point);
            // Image.gameObject.SetActive(true);

           
        }


        //drawer.drawing = Input.GetMouseButton(0);

        

        //ここ
        /*
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))    ///ボタンがクリックされたときにだけ反応するので、簡単に画面クリックを無視することが出来ます。
        {
            return;
        }
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if ((hit.Trackable is DetectedPlane) &&
                Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                    hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else
            {
                // Choose the prefab based on the Trackable that got hit.
                
                if (hit.Trackable is FeaturePoint)        ///特徴点に当たったら
                {
                    Debug.Log("hit");
                    drawer.drawing = true;
                    drawer.color = Color.blue;
                    drawer.transform.LookAt(hit.Pose.position);
                }
                else if (hit.Trackable is DetectedPlane)      ///検出平面に当たったら
                {
                    DetectedPlane detectedPlane = hit.Trackable as DetectedPlane;
                    Debug.Log("hit");
                        drawer.drawing = true;
                        drawer.color = Color.blue;
                   
                   
                }
                else
                {
                    Debug.Log("hit");
                    drawer.drawing = true;
                    drawer.color = Color.blue;
                    drawer.transform.LookAt(hit.Pose.position);
                }

               
            }
        }
        */






        foreach (var drawable in drawables)
            drawable.ClearGuid();

        drawer.Draw();
        drawer.DrawGuid();

        foreach (var drawable in drawables)
            drawable.Apply();
    }
    /*public void goright()
    {
        drawer.drawing = Input.GetMouseButton(0);
    }*/
    /*private void OnGUI()
    {
        var width = Screen.width * 0.2f;
        var height = Screen.height;
        var rect = new Rect(0, 0, width, height);

        GUI.backgroundColor = Color.gray;
        for (var i = 0; i < 1; i++)                   //i<2からi<1に変えた
        {
            var co = (CanvasObject)drawables[i];
            rect.x = (Screen.width - width) * i;

            GUILayout.BeginArea(rect, (GUIStyle)"box");
            GUILayout.Label(co.name);
            GUILayout.Label("position texture");
            GUILayout.Label(co.posTex, GUILayout.Width(width), GUILayout.Height(width));    ///imi
            GUILayout.Label("canvas texture");
            GUILayout.Label(co.drawingTex, GUILayout.Width(width), GUILayout.Height(width));
            GUILayout.EndArea();
        }
    }*/
}
