using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public float velocidad = 2;
    public float velocidadRoca = 4;
    public GameObject columna;
    public GameObject roca;
    public UIController uiController;

    public int playerLives = 1;

    public List<GameObject> columnaLista;

    void Start()
    {
        for(int i = 0; i < 21; i++)
        {
            columnaLista.Add(Instantiate(columna, new Vector2(-10+i,-3), Quaternion.identity));
        }
    }

    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
        
        for(int i = 0; i < columnaLista.Count; i++)
        {
            if (columnaLista[i].transform.position.x <= -10)
            {
                columnaLista[i].transform.position = new Vector3(10, -3, 0);
            }
            columnaLista[i].transform.position = columnaLista[i].transform.position + Time.deltaTime * velocidad * new Vector3(-1, 0, 0);
        }
        
        //Cambiar la posicion de la roca
        roca.transform.position = roca.transform.position + Time.deltaTime  * velocidadRoca * new Vector3(-1, 0, 0);

        //Mover la roca 
        if(roca.transform.position.x <= -10)
        {
            roca.transform.position = new Vector3(10, 1, 0);
        }
    }

    public int PlayerLives
    {
        get => playerLives;
        set{
            playerLives = value;
            print("Num de vidas restantes: " + playerLives);
            if(playerLives == 0)
            {
                //Mostrar pantalla de Gameover
                uiController.ActivateGameOverScreen();
            }
        }
    }
}
