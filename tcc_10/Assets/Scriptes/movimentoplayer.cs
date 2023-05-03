using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class movimentoplayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    public GameObject projetil;
    public GameObject bombaM;
    public Transform posicaoProjetil;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask layerGround;
    public int moedas;
    public TextMeshProUGUI textoMoedas;
    private int maca;
    public TextMeshProUGUI textomaca;
    private int agua;
    public TextMeshProUGUI textoagua;
    
    private inimigoR inimigoR;


    public GameObject inimigo;

    public float forcaimpulso;


    public GameObject historia;


    void Start()
    {

        inimigoR = FindObjectOfType(typeof(inimigoR)) as inimigoR;

        inimigoR.speed = 0;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(tempohistoria());
        
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

        //atirar();
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

        if (col.gameObject.tag == "maça")
        {
            maca += 1;

            textomaca.text = maca.ToString();

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "agua")
        {
            agua += 1;

            textoagua.text = agua.ToString();

            Destroy(col.gameObject);
        }

    }

    public void tiro()
    {
        Instantiate(projetil, posicaoProjetil.position, Quaternion.identity);
    }

    public void bomba()
    {
        Instantiate(bombaM, posicaoProjetil.position, Quaternion.identity);
    }

    public void pulo()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    public void direita()
    {

    }

    public void esquerda()
    {

    }

    IEnumerator tempohistoria()
    {
        
        yield return new WaitForSeconds(7);
        historia.SetActive(false);
        inimigoR.speed = 5;

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
