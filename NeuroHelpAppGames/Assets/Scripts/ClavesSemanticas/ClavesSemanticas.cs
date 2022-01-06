using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClavesSemanticas : MonoBehaviour
{
    private static ClavesSemanticas sharedInstance;

    int rand1,rand2 , rand3;
    int randa, randb, randc;
    bool boolContinue=false;
    public bool isToggle1Correct, isToggle2Correct, isToggle3Correct;
    //Objetos
    public GameObject SearchObjPhrase;


    //audios 

    public AudioSource aplausos;


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
    //public GameObject ToggleGroup1;
    

    public ToggleGroup ToggleGroup1;
    public ToggleGroup ToggleGroup2;
    public ToggleGroup ToggleGroup3;
    //Imagenes

    public GameObject visto1;
    public GameObject equiz1;
    public GameObject visto2;
    public GameObject equiz2;
    public GameObject visto3;
    public GameObject equiz3;

    public GameObject felicitacionesImg;
    public GameObject intentaloImg;
    public GameObject ButtonFinals;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.InicioCS1)
        {
            StartClavesSemanticas();
            GameManagerCS.GetInstance().currentGameState = GameStateCS.Idle1;
           
        }
        
        if(GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle1)
        {
            if (toglesOn()&& boolContinue)
            {
                buttonComprobar.gameObject.SetActive(true);
                boolContinue = false;
            }  
        }

        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.InicioCS2)
        {
            StartClavesSemanticas();
            GameManagerCS.GetInstance().currentGameState = GameStateCS.Idle2;

        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle2)
        {
            if (toglesOn() && boolContinue)
            {
                buttonComprobar.gameObject.SetActive(true);
                boolContinue = false;
            }
        }

        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.InicioCS3)
        {
            StartClavesSemanticas();
            GameManagerCS.GetInstance().currentGameState = GameStateCS.Idle3;

        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle3)
        {
            if (toglesOn() && boolContinue)
            {
                buttonComprobar.gameObject.SetActive(true);
                boolContinue = false;
            }
        }
    }

    //funciones

    public void SetAcFalseObjects()
    {
        //true para la primera pantalla

        object1.gameObject.SetActive(true);
        object2.gameObject.SetActive(true);
        object3.gameObject.SetActive(true);
        buttonOK.gameObject.SetActive(true);

        //false los primeros
        ToggleGroup1.gameObject.SetActive(false);
        ToggleGroup2.gameObject.SetActive(false);
        ToggleGroup3.gameObject.SetActive(false);
        visto1.SetActive(false);
        equiz1.SetActive(false);
        visto2.SetActive(false);
        equiz2.SetActive(false);
        visto3.SetActive(false);
        equiz3.SetActive(false);
        buttonComprobar.gameObject.SetActive(false);
        isToggle1Correct = false;
        isToggle2Correct = false;
        isToggle3Correct = false;
        felicitacionesImg.SetActive(false);
        intentaloImg.SetActive(false);
        ButtonFinals.SetActive(false);
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
        Transporte = new string[] { "trole", "taxi", "bicicleta" };
        Color = new string[] { "rojo", "azul", "amarillo" };
        Herramienta = new string[] { "martillo", "serrucho", "destornillador" };
        Cuerpo = new string[] { "cabeza", "brazos", "piernas" };
        // ArrayGroups = new string[][]{Bebidas, Ropa, Animal, Mueble, Comida
        //    , Deporte,Fruta,Transporte,Color,Herramienta,Cuerpo};

        ArrayGroups.Add(new KeyValuePair<string, string[]>("Bebida", Bebidas));
        ArrayGroups.Add(new KeyValuePair<string, string[]>("Ropa", Ropa));
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

        rand1 = UnityEngine.Random.Range(0, 11);
        rand2 = UnityEngine.Random.Range(0, 11);
        while (rand1 == rand2)
        {
            rand2 = UnityEngine.Random.Range(0, 11);
        }
        rand3 = UnityEngine.Random.Range(0, 11);
        while (rand1 == rand3 || rand2 == rand3)
        {
            rand3 = UnityEngine.Random.Range(0, 11);
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

        ToggleGroup1.gameObject.SetActive(true);
        ToggleGroup2.gameObject.SetActive(true);
        ToggleGroup3.gameObject.SetActive(true);
        
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
            ToggleText2A.text = ArrayGroups[rand2].Value[randb];
            while (randb == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText2B.text = ArrayGroups[rand2].Value[positionDos];
        }
        if (posRand == 1)
        {
            ToggleText2B.text = ArrayGroups[rand2].Value[randb];
            while (randb == positionDos)
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
            ToggleText3A.text = ArrayGroups[rand3].Value[randc];
            while (randc == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText3B.text = ArrayGroups[rand3].Value[positionDos];
        }
        if (posRand == 1)
        {
            ToggleText3B.text = ArrayGroups[rand3].Value[randc];
            while (randc == positionDos)
            {
                positionDos = UnityEngine.Random.Range(0, 3);
            }
            ToggleText3A.text = ArrayGroups[rand3].Value[positionDos];
        }

        buttonOK.gameObject.SetActive(false);
        //buttonComprobar.gameObject.SetActive(true);
    }

    private bool toglesOn()
    {
        if (ToggleGroup1.AnyTogglesOn()&& ToggleGroup2.AnyTogglesOn()&&ToggleGroup3.AnyTogglesOn())
        {
            boolContinue = true;
            return true;
        }
        return false;
    }

    public void Comprobar()
    {
        if (isToggle1Correct && isToggle2Correct && isToggle3Correct)
        {
            StartCoroutine(CorrectoWait());
           

        }
        else
        {
            StartCoroutine(InCorrectoWait());
            
        }
    }


    public IEnumerator CorrectoWait()
    {
        felicitacionesImg.SetActive(true);
        aplausos.Play();
        yield return new WaitForSeconds(5);

        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle1)
        {
            GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS2;
        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle2)
        {
            GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS3;
        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle3)
        {
            FelicitacionesFinal();
        }
        ApagarToggles();
        
        print("felicitaciones despues de 4 seg");
    }

    public IEnumerator InCorrectoWait()
    {
        intentaloImg.SetActive(true);
        yield return new WaitForSeconds(5);
        print("incorrecto despues de 4 seg");

        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle1)
        {
            GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS1;
        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle2)
        {
            GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS2;
        }
        if (GameManagerCS.GetInstance().currentGameState == GameStateCS.Idle3)
        {
            GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS3;
        }
        ApagarToggles();
    }

    private void ApagarToggles()
    {
        ToggleGroup1.SetAllTogglesOff();
        ToggleGroup2.SetAllTogglesOff();
        ToggleGroup3.SetAllTogglesOff();
    }


    public void FelicitacionesFinal()
    {
        ButtonFinals.SetActive(true);
    }

    public void Reiniciar()
    {
        GameManagerCS.GetInstance().currentGameState = GameStateCS.InicioCS1;
    }

    public void prenderVisto1()
    {
        visto1.SetActive(true);
    }

    public void prenderEquiz1()
    {
        equiz1.SetActive(true);
    }
    public void prenderVisto2()
    {
        visto2.SetActive(true);
    }

    public void prenderEquiz2()
    {
        equiz2.SetActive(true);
    }
    public void prenderVisto3()
    {
        visto3.SetActive(true);
    }

    public void prenderEquiz3()
    {
        equiz3.SetActive(true);
    }

}


