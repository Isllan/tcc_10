using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    private bool movingRight;
    private bool movingLeft;

    private Animator playerAC;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            sprite.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            movingLeft = false;
        }
        if (movingLeft)
        {
            sprite.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            movingRight = false;
        }
    }

    public void MovementRight(bool active)
    {
        movingRight = active;
    }

    public void MovementLeft(bool active)
    {
        movingLeft = active;
    }
}

