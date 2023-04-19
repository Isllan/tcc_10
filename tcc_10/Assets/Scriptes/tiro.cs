using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    public float velocidade;

    private void Update()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * velocidade);
    }

}
