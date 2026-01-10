using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10;

    Vector2 movement;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(
            transform.localPosition.x + xOffset,
            transform.localPosition.y + yOffset,
            0f);
    }

    public void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
    }
}