using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Destruido");
        Destroy(this.gameObject);
    }
}
