using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexForce : MonoBehaviour
{
    // The strength of the force pulling objects towards the black hole
    public float gravitationalPull = 10f;

    // The strength of the rotational force to create a spinning effect
    public float spinForce = 5f;

    // The radius within which objects are affected by the black hole
    public float effectRadius = 10f;

    void FixedUpdate()
    {
        // Find all colliders within the effect radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, effectRadius);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;

            // Ensure the object has a Rigidbody and it's not the black hole itself
            if (rb != null && rb.gameObject != gameObject)
            {
                Vector3 directionToBlackHole = transform.position - rb.position;

                // Apply gravitational force towards the black hole center
                rb.AddForce(directionToBlackHole.normalized * gravitationalPull);

                // Calculate the perpendicular direction for the spinning effect
                Vector3 perpendicularDirection = Vector3.Cross(directionToBlackHole, Vector3.up).normalized;

                // Apply rotational (spinning) force
                rb.AddTorque(perpendicularDirection * spinForce);
            }
        }
    }

    // Optional visualization in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}