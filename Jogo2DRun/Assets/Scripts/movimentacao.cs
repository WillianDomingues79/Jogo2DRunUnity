using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacao : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float velocidade;

    //Limitação Cenário
    public float limiteMaxY;
    public float limiteMinY;
    public float limiteMaxX;
    public float limiteMinX;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação entre eixos
        float horizontal = Input.GetAxisRaw("Horizontal");//Usa eixo HORIZONTAL, CONTROLE: SETAS <- ->
        float vertical = Input.GetAxisRaw("Vertical");

        //Limitação Cenário
        float posY = transform.position.y;
        float posX = transform.position.x;


        playerRb.velocity = new Vector2 (horizontal * velocidade, vertical * velocidade);//PARADO = 0, ANDANDO PRA FRENTE 2*1 = 2, ANDANDO PARA TRAS 2*(-2)=    -2


        //Limitação Cenário
        //Verificar Limite X
        if (transform.position.x > limiteMaxX)
        {
            posX = limiteMaxX;
        }
        else if (transform.position.x < limiteMinX)
        {
            posX = limiteMinX;
        }


        //Verificar Limite Y
        if (transform.position.y > limiteMaxY )
        {
            posY = limiteMaxY;
        }
        else if(transform.position.y < limiteMinY ) 
        { 
            posY = limiteMinY; 
        }

        transform.position = new Vector3(posX, posY, 0);
    }
}
