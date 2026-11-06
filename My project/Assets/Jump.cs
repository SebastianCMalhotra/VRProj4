using UnityEngine;
using UnityEngine.InputSystem;

public class VRJump : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 1.2f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundCheckDistance = 0.15f;
    [SerializeField] private LayerMask groundMask = ~0;

    private float verticalVelocity;

    void Update()
    {
        bool grounded = false;
        RaycastHit hit = default;

        // Only check for ground while not moving upward
        if (verticalVelocity <= 0f)
        {
            Vector3 origin = transform.position + Vector3.up * 0.1f;
            grounded = Physics.Raycast(origin, Vector3.down, out hit,
                0.1f + groundCheckDistance, groundMask, QueryTriggerInteraction.Ignore);
        }

        if (grounded)
        {
            verticalVelocity = 0f;

            Vector3 p = transform.position;
            p.y = hit.point.y;
            transform.position = p;

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
                
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
    }
}