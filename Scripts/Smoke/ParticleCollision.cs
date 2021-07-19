using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour
{

    void OnParticleCollision(GameObject obj)
    {
        Debug.Log("衝突");
        //Destroy(this.gameObject);
    }
}