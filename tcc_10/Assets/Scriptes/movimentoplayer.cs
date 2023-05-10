using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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

    public float horizontalInput;

    public bool ativador;

    public Button botaoDireita;


    public Vector2 movimentoHorizontal;

    Vector3 movement;


    public 
    void Start()
    {

        ativador = false;
        inimigoR = FindObjectOfType(typeof(inimigoR)) as inimigoR;

        inimigoR.speed = 0;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(tempohistoria());
        
    }
    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
      //  float verticalInput = Input.GetAxis("Vertical");

       

        transform.position += movement * speed * Time.deltaTime;

       if(ativador == true)
        {
            horizontalInput = 1;

             movement = new Vector3(1, 0f, 0f);

            transform.position += movement * speed * Time.deltaTime;

        }else
        {
            horizontalInput = 1;
        }
        
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

        Debug.Log("direita");
       
        if(ativador == false)
        {
           
            ativador = true;
        }else if(ativador == true)
        {
            
            ativador = false; 
        }
       



        Debug.Log("direito");
    }

    
  

    public void esquerda()
    {
        horizontalInput = -1;
        Debug.Log("esquerda");
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
