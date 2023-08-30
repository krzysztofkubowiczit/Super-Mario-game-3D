using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;

    // Skrypt pozwalaj¹cy na przesuwanie obiektów - NIEWYKORZYSTANE W GRZE, PRZEWIDZANE NA LEVEL 2


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
