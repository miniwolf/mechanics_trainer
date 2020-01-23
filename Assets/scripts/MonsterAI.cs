using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 40;
    public float MinRange = 1;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;

    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position,
            transform.TransformDirection(Vector3.forward),
            out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance <= AllowedRange && TargetDistance > MinRange)
            {
                EnemySpeed = 0.02f;
                if (AttackTrigger == 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        ThePlayer.transform.position,
                        EnemySpeed);
                }
            } else
            {
                EnemySpeed = 0;
            }
        }

        if (AttackTrigger == 1)
        {
            EnemySpeed = 0;
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }
}