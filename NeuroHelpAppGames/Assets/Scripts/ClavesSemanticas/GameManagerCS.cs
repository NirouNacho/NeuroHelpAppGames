using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Claves semanticas

public enum GameStateCS
{
    InicioCS1, CS1, InicioCS2, CS2, InicioCS3, CS3, InicioCS4, CS4, FinalCS,
    Idle1, Idle2, Idle3, Idle4
    //, FinalScore
}


public class GameManagerCS : MonoBehaviour
{
    private static GameManagerCS sharedInstance;

    public GameStateCS currentGameState;
    public GameObject felicitacionesImage;
    public GameObject buttonsFinals;


    private void Awake()
    {
        sharedInstance = this;
        currentGameState = new GameStateCS();
        currentGameState = new GameStateCS();
    }
    public static GameManagerCS GetInstance()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameStateCS.InicioCS1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartinicioCS1Game()
    {
        ChangeGameState(GameStateCS.InicioCS1);

    }
    public void StartCS1Game()
    {
        ChangeGameState(GameStateCS.CS1);

    }

    public void StartCS2Game()
    {
        ChangeGameState(GameStateCS.CS2);

    }

    public void StartCS3Game()
    {
        ChangeGameState(GameStateCS.CS3);

    }

    public void StartCS4Game()
    {
        ChangeGameState(GameStateCS.CS4);

    }
    private void ChangeGameState(GameStateCS newGameState)
    {

        switch (newGameState)
        {
            case GameStateCS.InicioCS1:
                buttonsFinals.SetActive(false);

                Debug.Log(currentGameState);
                break;
            case GameStateCS.CS1:
                buttonsFinals.SetActive(false);
                Debug.Log(currentGameState);
                break;
            case GameStateCS.InicioCS2:
                buttonsFinals.SetActive(false);
                Debug.Log(currentGameState);
                break;
            case GameStateCS.CS2:
                //Rep2.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateCS.InicioCS3:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = true;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateCS.CS3:
                //Rep3.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateCS.CS4:
                //Rep3.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateCS.FinalCS:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = true;
                buttonsFinals.SetActive(true);

                Debug.Log(currentGameState);
                break;
            default:
                currentGameState = GameStateCS.InicioCS1;
                break;

        }
        currentGameState = newGameState;

    }


}
