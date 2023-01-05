using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 moveDelta;

    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset
        moveDelta = new Vector3(x, y, 0);

        Flip();

        MovePlayer();

    }

    void Flip()
    {
       if(moveDelta.x > 0 )
       {
           transform.localScale = Vector3.one;
       } else if(moveDelta.x < 0)
       {
            transform.localScale = new Vector3(-1, 1, 1);
       }
    }

    void MovePlayer()
    {
        // Move Player
        transform.Translate(moveDelta.normalized * moveSpeed * Time.deltaTime);
    }
}
