using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossP2Attack : MonoBehaviour
{
    public int p2attackDamage = 40;
    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMask;

    public void p2Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(p2attackDamage);
        }
    }
}
