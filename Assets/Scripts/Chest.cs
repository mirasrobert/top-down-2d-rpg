using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public int moneyAmount = 5;
    bool isCollected = false;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isCollected = true;

            if(isCollected)
            {
                anim.SetBool("isCollected", isCollected);
            }
        }
    }

    // Will be called from animation event
    void Collect()
    {
        GameManager.instance.ShowText("+" + moneyAmount, 25, Color.yellow, transform.position, Vector3.up * 25, 0.5f);
    }

}
