using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FilasObjectTrigger : MonoBehaviour
{

    string objName;
    string objectTag;
    public SpriteRenderer childSpriteRenderer;
    public SpriteRenderer checkSpriteRenderer;
    GameObject child;
    GameObject check;
    Collider2D collider;

    private void Awake()
    {

        child = gameObject.transform.Find("Child").gameObject;
        check= gameObject.transform.Find("Check").gameObject;

        childSpriteRenderer = child.GetComponent<SpriteRenderer>();
        checkSpriteRenderer = check.GetComponent<SpriteRenderer>();

        collider = gameObject.GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

        collider = GetComponent<Collider2D>();
        
        // obj = GetComponent<>
        objName = gameObject.name;

        objectTag = gameObject.tag;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if (touch.phase == TouchPhase.Ended)
            {

                //para que el se de al finalizar el toque con la pantalla


                if (collider == touchedCollider)
                {
                    switch (objectTag)
                    {
                        case "primerafila":

                            if(Rep2.GetInstance().contPrimCol == 0)
                            {
                                TurnOnSquare();
                                Rep2.GetInstance().PrimeraCol[1,1]=gameObject;
                                Rep2.GetInstance().contPrimCol++;
                                collider.enabled = false;
                            }
                            else if (Rep2.GetInstance().contPrimCol==1)
                            {
                                Rep2.GetInstance().PrimeraCol[1, 2] = gameObject;
                                Rep2.GetInstance().contPrimCol++;
                            }
                             break;

                        case "segundafila":

                            if (Rep2.GetInstance().contSegCol == 0)
                            {
                                TurnOnSquare();
                                Rep2.GetInstance().SegundaCol[1, 1] = gameObject;
                                Rep2.GetInstance().contSegCol++;
                                collider.enabled = false;

                            }
                            else if (Rep2.GetInstance().contSegCol == 1)
                            {
                                Rep2.GetInstance().SegundaCol[1, 2] = gameObject;
                                Rep2.GetInstance().contSegCol++;
                            }

                            break;

                        case "tercerafila":

                            if (Rep2.GetInstance().contTerCol == 0)
                            {
                                TurnOnSquare();
                                Rep2.GetInstance().TerceraCol[1, 1] = gameObject;
                                Rep2.GetInstance().contTerCol++;
                                collider.enabled = false;
                            }
                            else if (Rep2.GetInstance().contTerCol == 1)
                            {
                                Rep2.GetInstance().TerceraCol[1, 2] = gameObject;
                                Rep2.GetInstance().contTerCol++;
                            }

                            break;

                        case "cuartafila":

                            if (Rep2.GetInstance().contCuarCol == 0)
                            {
                                TurnOnSquare();
                                Rep2.GetInstance().CuartaCol[1, 1] = gameObject;
                                Rep2.GetInstance().contCuarCol++;
                                collider.enabled = false;
                            }
                            else if (Rep2.GetInstance().contCuarCol == 1)
                            {
                                Rep2.GetInstance().CuartaCol[1, 2] = gameObject;
                                Rep2.GetInstance().contCuarCol++;
                            }

                            break;

                        case "quintafila":

                            if (Rep2.GetInstance().contQuinCol == 0)
                            {
                                TurnOnSquare();
                                Rep2.GetInstance().QuintaCol[1, 1] = gameObject;
                                Rep2.GetInstance().contQuinCol++;
                                collider.enabled = false;
                            }
                            else if (Rep2.GetInstance().contQuinCol == 1)
                            {
                                Rep2.GetInstance().QuintaCol[1, 2] = gameObject;
                                Rep2.GetInstance().contQuinCol++;
                            }

                            break;

                        default:
                            break;

                    }

                }

               
            }

        }

        //fuera touch collider
        switch(objectTag)
        {
            case "primerafila":
                if (Rep2.GetInstance().contPrimCol == 2)
                {
                    if (Rep2.GetInstance().PrimeraCol[1, 1].name == Rep2.GetInstance().PrimeraCol[1, 2].name)
                    {
                    
                        if (gameObject.name == Rep2.GetInstance().PrimeraCol[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep2.GetInstance().contPrimCol = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep2.GetInstance().PrimeraCol[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep2.GetInstance().PrimeraCol[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep2.GetInstance().contPrimCol = 0;
                        }    
                    }
                //desactivar fila
                //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if(Rep2.GetInstance().contPrimCol == 3)
                {
                    if ((gameObject.name == Rep2.GetInstance().PrimeraCol[1, 1].name)&&(childSpriteRenderer.enabled==true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();    
                    }
                }
                break;

            case "segundafila":
                if (Rep2.GetInstance().contSegCol == 2)
                {

                    if (Rep2.GetInstance().SegundaCol[1, 1].name == Rep2.GetInstance().SegundaCol[1, 2].name)
                    {
    
                        if (gameObject.name == Rep2.GetInstance().SegundaCol[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep2.GetInstance().contSegCol = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep2.GetInstance().SegundaCol[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep2.GetInstance().SegundaCol[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep2.GetInstance().contSegCol = 0;
                        }
                    }

                    //desactivar fila
                    //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if (Rep2.GetInstance().contSegCol == 3)
                {
                    if ((gameObject.name == Rep2.GetInstance().SegundaCol[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            case "tercerafila":
                if (Rep2.GetInstance().contTerCol == 2)
                {

                    if (Rep2.GetInstance().TerceraCol[1, 1].name == Rep2.GetInstance().TerceraCol[1, 2].name)
                    {

                        if (gameObject.name == Rep2.GetInstance().TerceraCol[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep2.GetInstance().contTerCol = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep2.GetInstance().TerceraCol[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep2.GetInstance().TerceraCol[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep2.GetInstance().contTerCol = 0;
                        }
                    }
                }
                if (Rep2.GetInstance().contTerCol == 3)
                {
                    if ((gameObject.name == Rep2.GetInstance().TerceraCol[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            case "cuartafila":
                if (Rep2.GetInstance().contCuarCol == 2)
                {

                    if (Rep2.GetInstance().CuartaCol[1, 1].name == Rep2.GetInstance().CuartaCol[1, 2].name)
                    {

                        if (gameObject.name == Rep2.GetInstance().CuartaCol[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep2.GetInstance().contCuarCol = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep2.GetInstance().CuartaCol[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep2.GetInstance().CuartaCol[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep2.GetInstance().contCuarCol = 0;
                        }
                    }

                }
                if (Rep2.GetInstance().contCuarCol == 3)
                {
                    if ((gameObject.name == Rep2.GetInstance().CuartaCol[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            case "quintafila":
                if (Rep2.GetInstance().contQuinCol == 2)
                {

                    if (Rep2.GetInstance().QuintaCol[1, 1].name == Rep2.GetInstance().QuintaCol[1, 2].name)
                    {

                        if (gameObject.name == Rep2.GetInstance().QuintaCol[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep2.GetInstance().contQuinCol = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep2.GetInstance().QuintaCol[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep2.GetInstance().QuintaCol[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep2.GetInstance().contQuinCol = 0;
                        }
                    }

                }
                if (Rep2.GetInstance().contQuinCol == 3)
                {
                    if ((gameObject.name == Rep2.GetInstance().QuintaCol[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            default:
                break;
        }

    }



    void TurnOnSquare()
    {
        childSpriteRenderer.enabled = true;
    }

    void TurnOffSquare()
    {
        childSpriteRenderer.enabled = false;
    }

    void TurnOnCheck()
    {
        checkSpriteRenderer.enabled = true;
    }
}
