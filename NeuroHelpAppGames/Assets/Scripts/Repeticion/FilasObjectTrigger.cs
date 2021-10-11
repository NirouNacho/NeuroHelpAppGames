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

                            if(Rep1.GetInstance().contPrimFila == 0)
                            {
                                TurnOnSquare();
                                Rep1.GetInstance().PrimeraFila[1,1]=gameObject;
                                Rep1.GetInstance().contPrimFila++;
                                collider.enabled = false;
                            }
                            else if (Rep1.GetInstance().contPrimFila==1)
                            {
                                Rep1.GetInstance().PrimeraFila[1, 2] = gameObject;
                                Rep1.GetInstance().contPrimFila++;
                            }
                            Debug.Log("PrimeraFila[1,1]: "+ Rep1.GetInstance().PrimeraFila[1, 1]);
                            Debug.Log("PrimeraFila[1,2]: " + Rep1.GetInstance().PrimeraFila[1, 2]);
                            break;

                        case "segundafila":

                            if (Rep1.GetInstance().contSegFila == 0)
                            {
                                TurnOnSquare();
                                Rep1.GetInstance().SegundaFila[1, 1] = gameObject;
                                Rep1.GetInstance().contSegFila++;
                                collider.enabled = false;

                            }
                            else if (Rep1.GetInstance().contSegFila == 1)
                            {
                                Rep1.GetInstance().SegundaFila[1, 2] = gameObject;
                                Rep1.GetInstance().contSegFila++;
                            }

                            break;

                        case "tercerafila":

                            if (Rep1.GetInstance().contTerFila == 0)
                            {
                                TurnOnSquare();
                                Rep1.GetInstance().TerceraFila[1, 1] = gameObject;
                                Rep1.GetInstance().contTerFila++;
                                collider.enabled = false;
                            }
                            else if (Rep1.GetInstance().contTerFila == 1)
                            {
                                Rep1.GetInstance().TerceraFila[1, 2] = gameObject;
                                Rep1.GetInstance().contTerFila++;
                            }

                            break;

                        case "cuartafila":

                            if (Rep1.GetInstance().contCuarFila == 0)
                            {
                                TurnOnSquare();
                                Rep1.GetInstance().CuartaFila[1, 1] = gameObject;
                                Rep1.GetInstance().contCuarFila++;
                                collider.enabled = false;
                            }
                            else if (Rep1.GetInstance().contCuarFila == 1)
                            {
                                Rep1.GetInstance().CuartaFila[1, 2] = gameObject;
                                Rep1.GetInstance().contCuarFila++;
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
                if (Rep1.GetInstance().contPrimFila == 2)
                {
                    if (Rep1.GetInstance().PrimeraFila[1, 1].name == Rep1.GetInstance().PrimeraFila[1, 2].name)
                    {
                        Debug.Log("Son igualeslos objetos");
                        Debug.Log("Pintalos verdes");
                        if (gameObject.name == Rep1.GetInstance().PrimeraFila[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep1.GetInstance().contPrimFila = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep1.GetInstance().PrimeraFila[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep1.GetInstance().PrimeraFila[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep1.GetInstance().contPrimFila = 0;
                        }    
                    }
                //desactivar fila
                //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if(Rep1.GetInstance().contPrimFila == 3)
                {
                    if ((gameObject.name == Rep1.GetInstance().PrimeraFila[1, 1].name)&&(childSpriteRenderer.enabled==true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();    
                    }
                }
                break;

            case "segundafila":
                if (Rep1.GetInstance().contSegFila == 2)
                {

                    if (Rep1.GetInstance().SegundaFila[1, 1].name == Rep1.GetInstance().SegundaFila[1, 2].name)
                    {
                        Debug.Log("Son igualeslos objetos");
                        Debug.Log("Pintalos verdes");
                        if (gameObject.name == Rep1.GetInstance().SegundaFila[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep1.GetInstance().contSegFila = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep1.GetInstance().SegundaFila[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep1.GetInstance().SegundaFila[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep1.GetInstance().contSegFila = 0;
                        }
                    }

                    //desactivar fila
                    //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if (Rep1.GetInstance().contSegFila == 3)
                {
                    if ((gameObject.name == Rep1.GetInstance().SegundaFila[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            case "tercerafila":
                if (Rep1.GetInstance().contTerFila == 2)
                {

                    if (Rep1.GetInstance().TerceraFila[1, 1].name == Rep1.GetInstance().TerceraFila[1, 2].name)
                    {
                        Debug.Log("Son igualeslos objetos");
                        Debug.Log("Pintalos verdes");
                        if (gameObject.name == Rep1.GetInstance().TerceraFila[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep1.GetInstance().contTerFila = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep1.GetInstance().TerceraFila[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep1.GetInstance().TerceraFila[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep1.GetInstance().contTerFila = 0;
                        }
                    }

                    //desactivar fila
                    //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if (Rep1.GetInstance().contTerFila == 3)
                {
                    if ((gameObject.name == Rep1.GetInstance().TerceraFila[1, 1].name) && (childSpriteRenderer.enabled == true))
                    {
                        TurnOffSquare();
                        TurnOnCheck();

                    }
                }

                break;

            case "cuartafila":
                if (Rep1.GetInstance().contCuarFila == 2)
                {

                    if (Rep1.GetInstance().CuartaFila[1, 1].name == Rep1.GetInstance().CuartaFila[1, 2].name)
                    {
                        Debug.Log("Son igualeslos objetos");
                        Debug.Log("Pintalos verdes");
                        if (gameObject.name == Rep1.GetInstance().CuartaFila[1, 1].name)
                        {
                            TurnOffSquare();
                            TurnOnCheck();
                        }
                        Rep1.GetInstance().contCuarFila = 3;
                    }
                    else
                    {
                        if ((gameObject.name == Rep1.GetInstance().CuartaFila[1, 1].name) && (collider.enabled == false))
                        {
                            TurnOffSquare();
                            collider.enabled = true;
                            if (gameObject.name == Rep1.GetInstance().CuartaFila[1, 1].name)
                            {
                                TurnOffSquare();
                                collider.enabled = true;
                            }
                            Rep1.GetInstance().contCuarFila = 0;
                        }
                    }

                    //desactivar fila
                    //con el estado 3 no entra en el touch y es como si estuviera desactivado.
                }
                if (Rep1.GetInstance().contCuarFila == 3)
                {
                    if ((gameObject.name == Rep1.GetInstance().CuartaFila[1, 1].name) && (childSpriteRenderer.enabled == true))
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
