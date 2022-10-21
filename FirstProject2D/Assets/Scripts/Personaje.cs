using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    Rigidbody2D caballero2D;
    public float maxvelocidad;

    //Voltear caballero
    bool voltearCaballero = true;
    SpriteRenderer caballeroRender;
    
    // Start is called before the first frame update
    void Start()
    {
        caballero2D = GetComponent<Rigidbody2D>();
        caballeroRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
        if(mover > 0 && !voltearCaballero)
        {
            voltear();
        }
        else if (mover <0 && voltearCaballero)
        {
            voltear();
        }

        caballero2D.velocity = new Vector2(mover * maxvelocidad, caballero2D.velocity.y);
    }

    void voltear()
    {
        voltearCaballero = !voltearCaballero;
        caballeroRender.flipX = !caballeroRender.flipX;
    }
}
