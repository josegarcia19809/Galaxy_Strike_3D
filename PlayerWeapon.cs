using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;


    bool isFiring = false;

    void Start()
    {
    }

    void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue input)
    {
        isFiring = input.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
}