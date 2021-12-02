using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameStateQyD
{
    InicioQyD1, QyD1, InicioQyD2, QyD2, InicioQyD3, QyD3, FinalQyD,Idle1, Idle2, Idle3
    //, FinalScore
}




public class GameManagerQue : MonoBehaviour
{

    public GameStateQyD currentGameState;
    private static GameManagerQue sharedInstance;
    public GameObject buttonsFinals;

    private void Awake()
    {
        sharedInstance = this;
        currentGameState = new GameStateQyD();
        currentGameState = GameStateQyD.InicioQyD1;
    }

    public static GameManagerQue GetInstance()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameStateQyD.InicioQyD1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInicioQyD1Game()
    {
        ChangeGameState(GameStateQyD.InicioQyD1);

    }
    public void StartDragQyD1Game()
    {
        ChangeGameState(GameStateQyD.QyD1);

    }

    public void StartInicioQyD2Game()
    {
        ChangeGameState(GameStateQyD.InicioQyD2);

    }
    public void StartDragQyD2Game()
    {
        ChangeGameState(GameStateQyD.QyD2);

    }
    public void StartInicioQyD3Game()
    {
        ChangeGameState(GameStateQyD.InicioQyD3);

    }
    public void StartDragQyD3Game()
    {
        ChangeGameState(GameStateQyD.QyD3);

    }
    private void ChangeGameState(GameStateQyD newGameState)
    {

        switch (newGameState)
        {
            case GameStateQyD.InicioQyD1:
                buttonsFinals.SetActive(false);

                Debug.Log(currentGameState);
                break;
            case GameStateQyD.QyD1:
                buttonsFinals.SetActive(false);
                Debug.Log(currentGameState);
                break;
            case GameStateQyD.InicioQyD2:
                buttonsFinals.SetActive(false);
                Debug.Log(currentGameState);
                break;
            case GameStateQyD.QyD2:
                //Rep2.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateQyD.InicioQyD3:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = true;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateQyD.QyD3:
                //Rep3.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;


            case GameStateQyD.FinalQyD:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = true;
                buttonsFinals.SetActive(true);

                Debug.Log(currentGameState);
                break;
            default:
                currentGameState = GameStateQyD.InicioQyD1;
                break;

        }
        currentGameState = newGameState;

    }

}
