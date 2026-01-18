using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;


    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }

    public void OnFire(InputValue input)
    {
        isFiring = input.isPressed;
        Debug.Log("isFiring");
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        // crosshair.position = Input.mousePosition;
        if (Mouse.current != null)
        {
            crosshair.position = Mouse.current.position.ReadValue();
        }
    }
}