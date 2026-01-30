using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log(other.gameObject.name);
    }
}
