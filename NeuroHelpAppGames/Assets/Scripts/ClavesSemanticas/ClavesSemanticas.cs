using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClavesSemanticas : MonoBehaviour
{
    private static ClavesSemanticas sharedInstance;


    //Objetos
    public GameObject SearchObjPhrase;



    //Textos

    public Text topText;

    public Text topImagePhrase1;
    public Text topImagePhrase2;
    public Text topImagePhrase3;

    public Text object1;
    public Text object2;
    public Text object3;

    public Text ToggleText1A;
    public Text ToggleText1B;
    public Text ToggleText2A;
    public Text ToggleText2B;
    public Text ToggleText3A;
    public Text ToggleText3B;

    //Toggle Groups
    public GameObject ToggleGroup1;
    public GameObject ToggleGroup2;
    public GameObject ToggleGroup3;

    //Imagenes

    public GameObject visto1;
    public GameObject equiz1;
    public GameObject visto2;
    public GameObject equiz2;
    public GameObject visto3;
    public GameObject equiz3;

    //Botones

    public Button buttonOK;

    //Grupos de palabras
    string[][] ArrayGroups;
    string[] Bebidas;
    string[] Ropa;
    string[] Animal;
    string[] Mueble;
    string[] Comida;
    string[] Deporte;
    string[] Fruta;
    string[] Transporte;
    string[] Color;
    string[] Herramienta;
    string[] Cuerpo;

    private void Awake()
    {
        sharedInstance = this;
        InitialziaTextArrays();

    }

    public static ClavesSemanticas GetInstance()
    {
        return sharedInstance;
    }

    public void StartClavesSemanticas()
    {
        topText.text = "Mira, memoriza y recuerda que palabra se encontraba en cada grupo: ";
        SetAcFalseObjects();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartClavesSemanticas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //funciones

    public void SetAcFalseObjects()
    {
        ToggleGroup1.SetActive(false);
        ToggleGroup2.SetActive(false);
        ToggleGroup3.SetActive(false);
        visto1.SetActive(false);
        equiz1.SetActive(false);
        visto2.SetActive(false);
        equiz2.SetActive(false);
        visto3.SetActive(false);
        equiz3.SetActive(false);
    }

    public void InitialziaTextArrays()
    {
        Bebidas= new string[] { "agua", "leche", "gaseosa" };
        Ropa = new string[] { "chaqueta", "pantalón", "camisa" };
        Animal = new string[] { "perro", "gato", "caballo" };
        Mueble = new string[] { "armario", "silla", "mesa" };
        Comida = new string[] { "sopa", "ensalada", "pizza" };
        Deporte = new string[] { "fútbol", "basket", "ciclismo" };
        Fruta = new string[] { "pera", "manzana", "piña" };
        Transporte = new string[] { "trole", "taxi", "bibicleta" };
        Color = new string[] { "rojo", "azul", "amarillo" };
        Herramienta = new string[] { "martillo", "serrrucho", "destornillador" };
        Cuerpo = new string[] { "cabeza", "brazos", "piernas" };
        ArrayGroups = new string[][]{Bebidas, Ropa, Animal, Mueble, Comida
            , Deporte,Fruta,Transporte,Color,Herramienta,Cuerpo};
    }

    private void Select3Random()
    {

    }
}
