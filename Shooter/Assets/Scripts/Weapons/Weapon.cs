using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponName;
    public float AttackRange;
    public float Damage;

    public float AttackForce;

    public Vector3 RightHandTarget;
    public Vector3 RightHandHint;
    public Vector3 RightHandRoatate;

    public Vector3 LeftHandTarget;
    public Vector3 LeftHandHint;

    public LayerMask DamageLayer;

    public Transform FireStart;

    private bool CanAttack = true;




    public void Attack()
    {
        if (!CanAttack) return;
        print("Attacked");
        Ray ray = new Ray(FireStart.position, FireStart.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, AttackRange, DamageLayer))
        {
            hit.rigidbody.AddForce(-hit.normal*AttackForce);
        }
        CanAttack = false;
        Invoke("ResetAttack", 3);
    }

    public void ResetAttack()
    {
        CanAttack = true;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(FireStart.position, FireStart.forward*AttackRange);
    }
}
