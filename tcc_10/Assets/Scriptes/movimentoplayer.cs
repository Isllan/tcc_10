using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class movimentoplayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    public GameObject projetil;
    public Transform posicaoProjetil;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask layerGround;
    public int moedas;
    public TextMeshProUGUI textoMoedas;


    public GameObject inimigo;

    public float forcaimpulso;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        transform.position += movement * speed * Time.deltaTime;

       

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("pulo");
        }

        atirar();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, layerGround);

        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Moedas")
        {
            moedas += 1;

            textoMoedas.text = moedas.ToString();

            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "inimigoR")
        {
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "mortesuperior")
        {
            Destroy(inimigo.gameObject);
            rb.AddForce(Vector2.up * forcaimpulso, ForceMode2D.Impulse);
        }
    }
        #region 
    public void atirar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projetil, posicaoProjetil.position, Quaternion.identity);

        }
    }





    #endregion
}
