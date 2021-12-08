using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClavesSemanticas : MonoBehaviour
{
    private static ClavesSemanticas sharedInstance;

    int rand1,rand2 , rand3;
    int randa, randb, randc;
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
    public Button buttonComprobar;

    //Grupos de palabras
    //string[][] ArrayGroups;
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

    List<KeyValuePair<string, string[]>> ArrayGroups;


    private void Awake()
    {
        sharedInstance = this;
        ArrayGroups = new List<KeyValuePair<string, string[]>>();
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
        Select3Random();
    }

    public void StartClavesSemanticasToggles()
    {
        topText.text = "Señala una palabra en cada grupo, de las que viste antes: ";
        SetAcFalseObjects2ndPart();
        Select3RandomToggle();

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
        buttonComprobar.gameObject.SetActive(false);
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
        Herramienta = new string[] { "martillo", "serrucho", "destornillador" };
        Cuerpo = new string[] { "cabeza", "brazos", "piernas" };
        // ArrayGroups = new string[][]{Bebidas, Ropa, Animal, Mueble, Comida
        //    , Deporte,Fruta,Transporte,Color,Herramienta,Cuerpo};

        ArrayGroups.Add(new KeyValuePair<string, string[]>("Bebida", Bebidas));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Animal", Animal));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Mueble", Mueble));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Comida", Comida));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Deporte", Deporte));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Fruta", Fruta));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Transporte", Transporte));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Color", Color));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Herramienta", Herramienta));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Parte del Cuerpo", Cuerpo));

    }

    private void Select3Random()
    {
        //Select 3 random from array groups

        rand1 = UnityEngine.Random.Range(0, 10);
        rand2 = UnityEngine.Random.Range(0, 10);
        while (rand1 == rand2)
        {
            rand2 = UnityEngine.Random.Range(0, 10);
        }
        rand3 = UnityEngine.Random.Range(0, 10);
        while (rand1 == rand3 || rand2 == rand3)
        {
            rand3 = UnityEngine.Random.Range(0, 10);
        }


        //Poner el nombre de los grupos a las cabeceras

        topImagePhrase1.text = ArrayGroups[rand1].Key;
        topImagePhrase2.text = ArrayGroups[rand2].Key;
        topImagePhrase3.text = ArrayGroups[rand3].Key;


        //Poner el nombre del objeto buscado del grupo
        
        randa = UnityEngine.Random.Range(0, 3);
        randb = UnityEngine.Random.Range(0, 3);
        randc = UnityEngine.Random.Range(0, 3);

        object1.text= ArrayGroups[rand1].Value[randa];
        object2.text = ArrayGroups[rand2].Value[randb];
        object3.text = ArrayGroups[rand3].Value[randc];


        //If you would like to print the group name now, you can do:

        // Debug.Log(groups[2].Key);
        //If you want to access a group you can do:

        // Debug.Log(groups[2].Value);
        //If you would like to access a name in a group:

        // Debug.Log(groups[2].Value[index]);
    }


    private void SetAcFalseObjects2ndPart()
    {
        object1.gameObject.SetActive(false); 
        object2.gameObject.SetActive(false); 
        object3.gameObject.SetActive(false);

        ToggleGroup1.SetActive(true);
        ToggleGroup2.SetActive(true);
        ToggleGroup3.SetActive(true);
        
    }

    private void Select3RandomToggle()
    {
        //Poner el nombre de los grupos a las cabeceras

        topImagePhrase1.text = "¿Que " + ArrayGroups[rand1].Key + " era?";
        topImagePhrase2.text = "¿Que " + ArrayGroups[rand2].Key + " era?";
        topImagePhrase3.text = "¿Que " + ArrayGroups[rand3].Key + " era?";

        

        int posRand= UnityEngine.Random.Range(0, 2);
        int positionDos = UnityEngine.Random.Range(0, 3);

        //Toggle 1
        if (posRand == 0)
        {
            ToggleText1A.text = ArrayGroups[rand1].Value[randa];
            while(randa== positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText1B.text = ArrayGroups[rand1].Value[positionDos];
        }
        if (posRand == 1)
        {
            ToggleText1B.text = ArrayGroups[rand1].Value[randa];
            while (randa == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText1A.text = ArrayGroups[rand1].Value[positionDos];
        }

        //Toggle 2

        posRand = UnityEngine.Random.Range(0, 2);
        positionDos = UnityEngine.Random.Range(0, 3);

        if (posRand == 0)
        {
            ToggleText2A.text = ArrayGroups[rand2].Value[randa];
            while (randa == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText2B.text = ArrayGroups[rand2].Value[positionDos];
        }
        if (posRand == 1)
        {
            ToggleText2B.text = ArrayGroups[rand2].Value[randa];
            while (randa == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText2A.text = ArrayGroups[rand2].Value[positionDos];
        }

        //Toggle 3
        posRand = UnityEngine.Random.Range(0, 2);
        positionDos = UnityEngine.Random.Range(0, 3);

        if (posRand == 0)
        {
            ToggleText3A.text = ArrayGroups[rand3].Value[randa];
            while (randa == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText3B.text = ArrayGroups[rand3].Value[positionDos];
        }
        if (posRand == 1)
        {
            ToggleText3B.text = ArrayGroups[rand3].Value[randa];
            while (randa == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText3A.text = ArrayGroups[rand3].Value[positionDos];
        }

        buttonOK.gameObject.SetActive(false);
        buttonComprobar.gameObject.SetActive(true);
    }
}


