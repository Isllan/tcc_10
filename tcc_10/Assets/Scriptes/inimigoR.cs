using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoR : MonoBehaviour
{
    public float speed;
    public float distance;
    bool isRight = true;
    public Transform groundCheck;
    public int trocardirecao;

    




    private void Start()
    {
        trocardirecao = 1;
    }
    // Update is called once per frame
    void Update()
    {

        

     

        transform.Translate(Vector2.right * speed * trocardirecao *  Time.deltaTime);




        /*RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        if(ground.collider == false)
        {
            if(isRight == true )
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }

        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "sensor1")
        {
            trocardirecao = -1;
        }
        if (collision.gameObject.tag == "sensor2")
        {
            trocardirecao = 1;
        }
        if(collision.gameObject.tag == "destruir")
        {
            Destroy(gameObject);
        }
    }
}
