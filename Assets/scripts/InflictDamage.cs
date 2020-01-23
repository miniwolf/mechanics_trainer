using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 2.7f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !AttackMotion.isAttacking)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,
                transform.TransformDirection(Vector3.forward),
                out hit))
            {
                TargetDistance = hit.distance;
                if (TargetDistance <= AllowedRange)
                {
                    hit.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}