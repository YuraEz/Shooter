using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplRadius;
    public float ExplForse;
    public LayerMask ExplLayer;

    [ContextMenu("Explode")]
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplRadius, ExplLayer);
        foreach (Collider collider in colliders)
        {
            collider.attachedRigidbody.AddExplosionForce(ExplForse, transform.position, ExplRadius);
        }
        Destroy(gameObject);
    }
}
