using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class direita : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private movimentoplayer _movimentoPlayer;
    public float input;
    public float sensibility = 3;
    bool pressing;

    private void Start()
    {
        _movimentoPlayer = FindObjectOfType(typeof(movimentoplayer)) as movimentoplayer;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
    }

    void Update()
    {
        if (pressing)
        {
           _movimentoPlayer.movement += Time.deltaTime * sensibility;
        }
        else
        {
            _movimentoPlayer.movement -= Time.deltaTime * sensibility;
        }


        _movimentoPlayer.movement = Mathf.Clamp(_movimentoPlayer.movement, 0, 1);

        
    }
}

