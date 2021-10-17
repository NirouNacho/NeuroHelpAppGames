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
    Vector3[] Recorrido2Positions;
    Vector3[] Recorrido3Positions;
    Vector3[] Recorrido4Positions;
    GameObject[] objNumeros;

    //objetos tocados

    GameObject primerTocado;
    GameObject medioTocado;
    GameObject ultimoTocado;

    int contObjeto;
    int maxObjetos;

    public GameObject SearchObjPhrase;
    public GameObject felicitacionesImage;

    public Color colorWhite = Color.white;
    public Color colorGreen = new Color(51f,176f, 44f, 1f);

    private void Awake()
    {
        sharedInstance = this;

        Recorrido1Positions= new Vector3[8];
        Recorrido1Positions[0] = new Vector3(-6.54f, 1.52f, 0f);
        Recorrido1Positions[1] = new Vector3(0.47f, 0.5f, 0f);
        Recorrido1Positions[2] = new Vector3(-6.26f, -2.83f, 0f);
        Recorrido1Positions[3] = new Vector3(2.79f, -2.39f, 0f);
        Recorrido1Positions[4] = new Vector3(6.79f, 0.85f, 0f);

        Recorrido2Positions = new Vector3[8];
        Recorrido2Positions[0] = new Vector3(7.15f, -3.18f, 0f);
        Recorrido2Positions[1] = new Vector3(-7.7f, 1.67f, 0f);
        Recorrido2Positions[2] = new Vector3(0.18f, -3.69f, 0f);
        Recorrido2Positions[3] = new Vector3(-6.5f, -1.8f, 0f);
        Recorrido2Positions[4] = new Vector3(8.35f, 1.5f, 0f);
        Recorrido2Positions[5] = new Vector3(0.22f, 0.91f, 0f);

        Recorrido3Positions = new Vector3[8];
        Recorrido3Positions[0] = new Vector3(8.26f, -3.74f, 0f);
        Recorrido3Positions[1] = new Vector3(-3.31f, -1.26f, 0f);
        Recorrido3Positions[2] = new Vector3(8.11f, 1.71f, 0f);
        Recorrido3Positions[3] = new Vector3(-4.78f, -3.43f, 0f);
        Recorrido3Positions[4] = new Vector3(5.84f, -1.07f, 0f);
        Recorrido3Positions[5] = new Vector3(-7.51f, 2.22f, 0f);
        Recorrido3Positions[6] = new Vector3(0.93f, 2.27f, 0f);

        Recorrido4Positions = new Vector3[8];
        Recorrido4Positions[0] = new Vector3(2.4f, -3.79f, 0f);
        Recorrido4Positions[1] = new Vector3(-0.28f, 2.12f, 0f);
        Recorrido4Positions[2] = new Vector3(-6.59f, -3.44f, 0f);
        Recorrido4Positions[3] = new Vector3(8.3f, 0.91f, 0f);
        Recorrido4Positions[4] = new Vector3(4.98f, -0.67f, 0f);
        Recorrido4Positions[5] = new Vector3(6.83f, -2.93f, 0f);
        Recorrido4Positions[6] = new Vector3(-3.81f, -1.02f, 0f);
        Recorrido4Positions[7] = new Vector3(-7.75f, 1.36f, 0f);

        contObjeto = 0;
        maxObjetos = 5;

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
        contObjeto = 0;
        maxObjetos = 4;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);

        ImprimirNumeros(objNumeros,4, Recorrido1Positions);// 5 numeros
        Debug.Log("StartReco1Game");


        //GameManagerRecorrido.GetInstance().StartReco1Game();
    }

    public void StartReco2Game()
    {
        contObjeto = 0;
        maxObjetos = 5;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);

        ImprimirNumeros(objNumeros, 5, Recorrido2Positions);// 6 numeros
        Debug.Log("StartReco2Game");
    }

    public void StartReco3Game()
    {
        contObjeto = 0;
        maxObjetos = 6;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);

        ImprimirNumeros(objNumeros, 6, Recorrido3Positions);// 7 numeros
        Debug.Log("StartReco3Game");
    }
    public void StartReco4Game()
    {
        contObjeto = 0;
        maxObjetos = 7;
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);

        ImprimirNumeros(objNumeros, 7, Recorrido4Positions);// 8 numeros
        Debug.Log("StartReco4Game");
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

        if (contObjeto == maxObjetos)
        {
            felicitacionesImage.SetActive(true);
            DestroyObjects("primerafila");
            SearchObjPhrase.gameObject.SetActive(false);
            Camera.main.backgroundColor = colorGreen;
            
            
            StartCoroutine(GameManagerRecorrido.GetInstance().FelicidadesWait(GameStateReco.InicioReco2));
            GameManagerRecorrido.GetInstance().GetComponent<Rep1>().enabled = false;
        }

    }

    private GameObject[] LlenarArrayObj(string direccion)
    {
        return objNumeros = Resources.LoadAll<GameObject>(direccion);
    }

    private void ImprimirNumeros(GameObject[] aImprimir,int cantidadVeces, Vector3[] recorridoPos)
    {
        GameObject g;

        for (int i = 0; i <= cantidadVeces; i++)//5 colums
        {
            g = Instantiate(aImprimir[i]);
            g.transform.position = recorridoPos[i];
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

    private void DestroyObjects(string tag)
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);


        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }



    }
}
