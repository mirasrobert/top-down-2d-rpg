using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    protected Vector3 moveDelta;

    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    protected virtual void updateMotor(Vector3 input)
    {
        moveDelta = input;

        Flip(moveDelta);

        MovePlayer(moveDelta);
    }

    void Flip(Vector3 moveDelta)
    {
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void MovePlayer(Vector3 moveDelta)
    {
        // Move Player
        transform.Translate(moveDelta.normalized * moveSpeed * Time.deltaTime);
    }

}
