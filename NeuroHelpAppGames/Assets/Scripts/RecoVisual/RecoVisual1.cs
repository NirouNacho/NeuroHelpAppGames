﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoVisual1 : MonoBehaviour
{

    private static RecoVisual1 sharedInstance;

    public GameObject SearchObjPhrase;
    public GameObject felicitacionesImage;

    //objetos para boton
    public GameObject ButtonContinuar1;
    public GameObject ButtonContinuar2;
    public GameObject ButtonContinuar3;
    public GameObject ButtonContinuar4;

    //objectos para texto
    public GameObject TextForOne;
    public GameObject TextForTwo;

    //textos
    public Text TxtSearchObjPhrase;

    public Text nombrePara1;
    public Text nombrePara2L;
    public Text nombrePara2R;

    public Text SearchObjPhraseTxt;

    GameObject[] tarjetas;
    GameObject[] tarjetasMostrar2;

    string auxiliarText;
    string auxiliarTextL;
    string auxiliarTextR;

    public GameObject tarjetaRndm1;
    public GameObject tarjetaRndm2L;
    public GameObject tarjetaRndm2R;


    public Color colorWhite = Color.white;
    public Color colorGreen = new Color(51f, 176f, 44f, 1f);
    public Color colorCeleste = new Color(32f, 208f, 231f, 1f);


    private void Awake()
    {
        sharedInstance = this;
        tarjetas = LlenarArrayObj("Prefabs/RecoVisual/Tarjetas");
        tarjetasMostrar2 = new GameObject[3];

        ButtonContinuar2.SetActive(false);
    }


    public static RecoVisual1 GetInstance()
    {
        return sharedInstance;
    }

    public void StartRV1Game()
    {
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);
        TxtSearchObjPhrase.text = "Mira detenidamente a la figura e intenta memorizarla";
        TextForOne.SetActive(true);
        if(GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.InicioRV1)
        {
            ButtonContinuar1.SetActive(true);
        }

        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.InicioRV2)
        {
            ButtonContinuar2.SetActive(true);
        }

        tarjetaRndm1 = GetRandomSelected(tarjetas);
        tarjetaRndm1 = Instantiate(tarjetaRndm1);
        tarjetaRndm1.transform.position = new Vector3(0, 0, 0);
        auxiliarText = tarjetaRndm1.name;

        auxiliarText = auxiliarText.Replace("Tarjeta", "");
        auxiliarText = auxiliarText.Replace("(Clone)", "");
        nombrePara1.text = auxiliarText;


    }
    
    public void StartRV2Game()
    {
        StartRV1Game();
        
    }

    public void StartRV3Game()
    {
        felicitacionesImage.SetActive(false);
        SearchObjPhrase.SetActive(true);
        TextForTwo.SetActive(true);
        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.InicioRV3)
        {
            ButtonContinuar3.SetActive(true);
        }
        else
        {
            ButtonContinuar4.SetActive(true);
        }


        tarjetaRndm2L = GetRandomSelected(tarjetas);
        tarjetaRndm2R = GetRandomSelected(tarjetas);
        while(tarjetaRndm2L== tarjetaRndm2R)
        {
            tarjetaRndm2R = GetRandomSelected(tarjetas);
        }
        tarjetaRndm2L = Instantiate(tarjetaRndm2L);
        tarjetaRndm2R = Instantiate(tarjetaRndm2R);

        tarjetaRndm2L.transform.position = new Vector3(4.15f, 0.4f, 0);
        tarjetaRndm2R.transform.position = new Vector3(3.9f, 0.4f, 0);
        auxiliarTextL = tarjetaRndm2L.name;
        auxiliarTextR = tarjetaRndm2R.name;

        auxiliarTextL = auxiliarTextL.Replace("Tarjeta", "");
        auxiliarTextL = auxiliarTextL.Replace("(Clone)", "");

        auxiliarTextR = auxiliarTextR.Replace("Tarjeta", "");
        auxiliarTextR = auxiliarTextR.Replace("(Clone)", "");

        nombrePara2L.text = auxiliarTextL;
        nombrePara2R.text = auxiliarTextR;

    }


    void Start()
    {
        StartRV1Game();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.RV1)
        {
            tarjetaRndm1.SetActive(false);
            TextForOne.SetActive(false);
            ButtonContinuar1.SetActive(false);

            TxtSearchObjPhrase.text = "¿Qué figura apareció antes?";
            print("Lleno tarjetas");
            llenarTarjetaMostrar2(tarjetasMostrar2);
            print("Imprimo tarjetas");
            imprimirTarjetas2Mostrar(tarjetasMostrar2);
            print("Estado update1 "+GameManagerRecoVisual.GetInstance().currentGameState);
            GameManagerRecoVisual.GetInstance().currentGameState = GameStateRV.Idle1;
        }

        if(GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.InicioRV2)
        {
            StartRV2Game();
            GameManagerRecoVisual.GetInstance().currentGameState = GameStateRV.Idle2;
        }

        if(GameManagerRecoVisual.GetInstance().currentGameState == GameStateRV.RV2)
        {
            tarjetaRndm1.SetActive(false);
            TextForOne.SetActive(false);
            ButtonContinuar2.SetActive(false);

            TxtSearchObjPhrase.text = "¿Qué figura apareció antes?";
            print("Lleno tarjetas");
            llenarTarjetaMostrar2(tarjetasMostrar2);
            print("Imprimo tarjetas");
            imprimirTarjetas2Mostrar(tarjetasMostrar2);
            print("Estado update1 " + GameManagerRecoVisual.GetInstance().currentGameState);
            GameManagerRecoVisual.GetInstance().currentGameState = GameStateRV.Idle2;
        }


    }

    public GameObject[] LlenarArrayObj(string direccion)
    {
        return tarjetas = Resources.LoadAll<GameObject>(direccion);
    }

    public GameObject GetRandomSelected(GameObject[] array)
    {
        return array[UnityEngine.Random.Range(0, 10)];
    }

    public GameObject[] llenarTarjetaMostrar2(GameObject[] aLLenar)
    {
        GameObject auxObj;
        GameObject tarjetaR1 = tarjetaRndm1;
        string nameTarjetaRndm1 = tarjetaR1.name;
        nameTarjetaRndm1 = nameTarjetaRndm1.Replace("(Clone)", "");
        tarjetaRndm1.name = nameTarjetaRndm1;

        int randoma = UnityEngine.Random.Range(0, 2);

        for (int y=0;y <= 1; y++)
        {
            int a = UnityEngine.Random.Range(0, 11);
            auxObj = tarjetas[a];
            bool canIn = false;

            for (int x = 0; x <= y; x++)
            {
                if (aLLenar[x] == null)
                {
                    canIn = true;
                    if (auxObj.name == nameTarjetaRndm1)
                    {
                        canIn = false;
                        y--;
                        break;
                    }
                    
                }
                else if (aLLenar[x].name == auxObj.name) //auxiliarText
                {
                    canIn = false;
                    y--;
                    break;
                }
                
            }

            if (canIn)
            {
                
                aLLenar[y] = auxObj;

            }

        }

        aLLenar[randoma] = tarjetaR1;
        Debug.Log("tarjetaRndm1.name " + tarjetaRndm1.name);
        for (int i = 0; i <= 1; i++)
        {
            Debug.Log("Array a llenar:  aLLenar[" + i + "] " + aLLenar[i]);
        }
        return aLLenar;
    }


    public GameObject[] llenarTarjetaMostrar4(GameObject[] aLLenar)
    {
        GameObject auxObj;
        GameObject tarjetaR1 = tarjetaRndm1;
        string nameTarjetaRndm1 = tarjetaR1.name;
        nameTarjetaRndm1 = nameTarjetaRndm1.Replace("(Clone)", "");
        tarjetaRndm1.name = nameTarjetaRndm1;

        int randoma = UnityEngine.Random.Range(0, 2);

        for (int y = 0; y <= 1; y++)
        {
            int a = UnityEngine.Random.Range(0, 11);
            auxObj = tarjetas[a];
            bool canIn = false;

            for (int x = 0; x <= y; x++)
            {
                if (aLLenar[x] == null)
                {
                    canIn = true;
                    if (auxObj.name == nameTarjetaRndm1)
                    {
                        canIn = false;
                        y--;
                        break;
                    }

                }
                else if (aLLenar[x].name == auxObj.name) //auxiliarText
                {
                    canIn = false;
                    y--;
                    break;
                }

            }

            if (canIn)
            {

                aLLenar[y] = auxObj;

            }

        }

        aLLenar[randoma] = tarjetaR1;
        Debug.Log("tarjetaRndm1.name " + tarjetaRndm1.name);
        for (int i = 0; i <= 1; i++)
        {
            Debug.Log("Array a llenar:  aLLenar[" + i + "] " + aLLenar[i]);
        }
        return aLLenar;
    }

    public void imprimirTarjetas2Mostrar(GameObject[] aImprimir)
    {
        GameObject g;
        Vector3[] posTarjetas2 = new Vector3[2];
        posTarjetas2[0] = new Vector3(-3,0,0);
        posTarjetas2[1] = new Vector3(4, 0, 0);

        for (int i = 0; i <= 1; i++)
        {
            g = Instantiate(aImprimir[i]);
            g.transform.position = posTarjetas2[i];
            g.SetActive(true);
        }
    }

    public void DestroyObjects(string tag)
    {

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);


        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }

    }

  

}

   