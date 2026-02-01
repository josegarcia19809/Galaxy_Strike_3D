using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyedFX;
    [SerializeField] private int HitPoints = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        HitPoints--;
        if (HitPoints <= 0)
        {
            Instantiate(destroyedFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}