using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector3 targetPointPosition = new Vector3(
            mousePos.x,
            mousePos.y,
            targetDistance
        );

        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
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