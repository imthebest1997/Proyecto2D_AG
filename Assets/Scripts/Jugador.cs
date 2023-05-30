using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    public float fuerzaSalto = 250;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    public GameManager gameManager;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("startSaltar", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            animator.SetBool("startSaltar", false);
        }

        if (collision.gameObject.CompareTag("Roca"))
        {
            gameManager.PlayerLives--;
        }
    }
}
