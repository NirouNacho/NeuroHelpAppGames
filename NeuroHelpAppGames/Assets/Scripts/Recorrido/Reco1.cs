using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reco1 : MonoBehaviour
{
    public GameObject lineaGenerar;

    Linea linea;

    GameObject lineaActual;

    private static Reco1 sharedInstance;

    Vector3[] Recorrido1Positions;

    GameObject[] objNumeros;

    //objetos tocados

    public GameObject primerTocado;
    public GameObject medioTocado;
    public GameObject ultimoTocado;

    public int contObjeto;

    private void Awake()
    {
        sharedInstance = this;
        Recorrido1Positions= new Vector3[8];
        Recorrido1Positions[0] = new Vector3(-6.54f, 1.52f, 0f);
        Recorrido1Positions[1] = new Vector3(0.47f, 0.5f, 0f);
        Recorrido1Positions[2] = new Vector3(-6.26f, -2.83f, 0f);
        Recorrido1Positions[3] = new Vector3(2.79f, -2.39f, 0f);
        Recorrido1Positions[4] = new Vector3(6.79f, 0.85f, 0f);
        
        contObjeto = 0;

        objNumeros = new GameObject[9];
        primerTocado = new GameObject();
        medioTocado = new GameObject();
        ultimoTocado = new  GameObject ();

        LlenarArrayObj("Prefabs/Recorridos/Numeros");


    }

    public static Reco1 GetInstance()
    {
        return sharedInstance;
    }

    public void StartReco1Game()
    {
        ImprimirNumeros(objNumeros);
        Debug.Log("StartReco1Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //obtener objeto
            primerTocado=raycastToObject();
            Debug.Log("primerTocado"+primerTocado);
            Debug.Log("objNumeros[contObjeto] mas el clone" + objNumeros[contObjeto].name + "(Clone)");
            if (primerTocado.name == objNumeros[contObjeto].name+"(Clone)")
            {
                //Dibujar linea
                Vector3 dondeGenerar = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
                lineaActual = Instantiate(lineaGenerar, dondeGenerar, transform.rotation);
                linea = lineaActual.GetComponent<Linea>();
            }
            
        }

        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Stationary)
        {
            try
            {
                medioTocado =raycastToObject();
                if ( medioTocado.name!= objNumeros[contObjeto].name + "(Clone)")
                {
               
                        ultimoTocado = raycastToObject();
                        Debug.Log("ultimo Tocado" + ultimoTocado);
                    
                    
                    Debug.Log("contObjeto " + contObjeto);

                    linea = null;
                }
            }
            catch (Exception e)
            {
                print(e);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if ((primerTocado.name == objNumeros[contObjeto].name + "(Clone)") &&(ultimoTocado.name == objNumeros[contObjeto+1].name + "(Clone)"))
            {
                contObjeto++;
            }
            else if(ultimoTocado.name != objNumeros[contObjeto + 1].name + "(Clone)")
            {
                Destroy(lineaActual);
            }
 
            linea = null;
        }

        if (linea != null)
        {
            Vector2 ratonPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            linea.DibujarLinea(ratonPos);
        }
    }

    private GameObject[] LlenarArrayObj(string direccion)
    {
        return objNumeros = Resources.LoadAll<GameObject>(direccion);
    }

    private void ImprimirNumeros(GameObject[] aImprimir)
    {
        GameObject g;

        for (int i = 0; i <= 4; i++)//5 colums
        {
            g = Instantiate(aImprimir[i]);
            g.transform.position = Recorrido1Positions[i];
        }
    }


    //devuelve el objeto tocado por raycast

    public GameObject raycastToObject()
    {
        GameObject tocadoObj ;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);
            return tocadoObj = hit.transform.gameObject;
            Debug.Log(" Tocado " + hit.transform.name);
        }
        else
        {
            return null;
        }
    }
}
