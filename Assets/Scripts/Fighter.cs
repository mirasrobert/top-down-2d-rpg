using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoints = 10;
    public int maxhitPoints = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 0.5f;
    protected float lastImmuneTime;

    // Push
    protected Vector3 pushDirection;

    // All fighters can receive damage and can die
    protected virtual void ReceiveDamage(Damage damage)
    {
        if(Time.time - lastImmuneTime > immuneTime)
        {

            lastImmuneTime = Time.time;
            hitPoints -= damage.damageAmount;
            pushDirection = (transform.position - damage.origin).normalized * damage.pushForce;

            GameManager.instance.ShowText("-" + damage.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 25, 0.5f);

            if (hitPoints <= 0)
            {
                hitPoints = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Dead");
    }

}
