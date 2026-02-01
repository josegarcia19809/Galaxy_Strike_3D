using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject destroyedFX;
    [SerializeField] private int HitPoints = 3;
    [SerializeField] private int scoreValue = 10;
    
    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        HitPoints--;
        if (HitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Destroyed enemy");
        }
    }
}