using System.Collections;
using UnityEngine;

public class AttackMotion : MonoBehaviour
{
    public GameObject Player;
    public int AttackStatus;
    public static bool isAttacking = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && AttackStatus == 0)
        {
            StartCoroutine(AttackMotionFunction());
        }
    }

    private IEnumerator AttackMotionFunction()
    {
        isAttacking = true;
        AttackStatus = 1;
        Player.GetComponent<Animation>().Play("PlayerAttack");
        AttackStatus = 2;
        yield return new WaitForSeconds(1.0f);
        AttackStatus = 0;
        isAttacking = false;
    }
}