using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyedFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
