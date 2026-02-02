using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedFX;
    
    GameSceneManager gameSceneManager;
    
    
    void Start()
    {
     gameSceneManager = FindFirstObjectByType<GameSceneManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(destroyedFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log(other.gameObject.name);
    }
}
