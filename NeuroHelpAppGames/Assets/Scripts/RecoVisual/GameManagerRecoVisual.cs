using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStateRV
{
    InicioRV1, RV1, InicioRV2, RV2, InicioRV3, RV3, FinalRV,Idle1//, FinalScore
}


public class GameManagerRecoVisual : MonoBehaviour
{

    public GameStateRV currentGameState;
    private static GameManagerRecoVisual sharedInstance;
    public GameObject felicitacionesImage;
    public Canvas I1erJuego;
    public Canvas V2doJuego;
    public Canvas N3erJuego;
    public Canvas Final;

    private void Awake()
    {
        sharedInstance = this;
        currentGameState =  new GameStateRV();
        currentGameState = GameStateRV.InicioRV1;
}
    public static GameManagerRecoVisual GetInstance()
    {
        return sharedInstance;
    }



    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameStateRV.InicioRV1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartinicioRv1Game()
    {
        ChangeGameState(GameStateRV.InicioRV1);
        
    }
    public void StartRv1Game()
    {
        ChangeGameState(GameStateRV.RV1);
        
    }
    private void ChangeGameState(GameStateRV newGameState)
    {

        switch (newGameState)
        {
            case GameStateRV.InicioRV1:
               // I1erJuego.enabled = false;
               // V2doJuego.enabled = false;
               // N3erJuego.enabled = false;
               // Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRV.RV1:
                //Rep1.GetInstance().SearchObjPhrase.SetActive(true);
               // I1erJuego.enabled = true;
              //  V2doJuego.enabled = false;
               // N3erJuego.enabled = false;
              //  Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRV.InicioRV2:
               // I1erJuego.enabled = false;
               // V2doJuego.enabled = true;
               // N3erJuego.enabled = false;
               // Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRV.RV2:
                Rep2.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateRV.InicioRV3:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = true;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRV.RV3:
                Rep3.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateRV.FinalRV:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = true;
                Debug.Log(currentGameState);
                break;
            default:
                currentGameState = GameStateRV.InicioRV1;
                break;

        }
        currentGameState = newGameState;

    }



    public IEnumerator FelicidadesWait(GameStateRV state)
    {
        yield return new WaitForSeconds(3);  
        Debug.Log("salida de felicidades");
        felicitacionesImage.SetActive(false);
        ChangeGameState(state);
        Debug.Log("Este es el estado " + state);
    }

}
