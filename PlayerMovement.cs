using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10;
    [SerializeField] float xClampRange = 5;
    [SerializeField] float yClampRange = 5;

    [SerializeField] float controlRollFactor = 20;
    [SerializeField] float controlPicthFactor = 20;
    [SerializeField] float rotationSpeed = 10;
    Vector2 movement;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = -controlPicthFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
    }
}