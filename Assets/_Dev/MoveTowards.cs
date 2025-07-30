using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public Transform initialTarget;
    public float maxSpeed = 5f;
    public float stoppingDistance = 1f;
    public float acceleration = 10f;
    public float braking = 10f;
    public float rotationSpeed = 10f; // How quickly it rotates to face movement direction

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = 0f;
        initialTarget = target;
    }

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 toTarget = target.position - transform.position;
        float distance = toTarget.magnitude;

        if (distance < stoppingDistance)
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, braking * Time.fixedDeltaTime);
        }
        else
        {
            Vector3 desiredVelocity = toTarget.normalized * maxSpeed;
            float speedFactor = Mathf.Clamp01((distance - stoppingDistance) / stoppingDistance);
            desiredVelocity *= speedFactor;
            rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, desiredVelocity, acceleration * Time.fixedDeltaTime);
        }

        // Rotate to face direction of motion if moving
        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rb.linearVelocity.normalized, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}
