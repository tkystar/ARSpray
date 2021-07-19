using UnityEngine;

public class UpdateColor : MonoBehaviour
{
    private GetColor getColor;
    Renderer renderer;
    void Start()
    {
        getColor = GameObject.FindObjectOfType<GetColor>();
        renderer=this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.color = getColor.color;
    }
}