using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateReco
{
    InicioReco1, Reco1, InicioReco2, Reco2, InicioReco3, Reco3, InicioReco4, Reco4, FinalReco//, FinalScore
}
public class GameManagerRecorrido : MonoBehaviour
{
   

    public GameStateReco currentGameState = GameStateReco.InicioReco1;
    private static GameManagerRecorrido sharedInstance;
    public GameObject felicitacionesImage;
    public Canvas I1erJuego;
    public Canvas V2doJuego;
    public Canvas N3erJuego;
    public Canvas N4toJuego;
    public Canvas Final;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManagerRecorrido GetInstance()
    {
        return sharedInstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameStateReco.InicioReco1;
        //Canvas 
        I1erJuego.enabled = true;
        V2doJuego.enabled = false;
        N3erJuego.enabled = false;
        N4toJuego.enabled = false;
        Final.enabled = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepeatGames()
    {
        ChangeGameState(GameStateReco.Reco1); 
    }

    public void StartReco1Game()
    {
        ChangeGameState(GameStateReco.InicioReco1);
       
    }
    public void StartReco2Game()
    {
        ChangeGameState(GameStateReco.Reco2);

    }
    public void StartReco3Game()
    {
        ChangeGameState(GameStateReco.Reco3);

    }

    public void StartReco4Game()
    {
        ChangeGameState(GameStateReco.Reco4);

    }

    private void ChangeGameState(GameStateReco newGameState)
    {

        switch (newGameState)
        {
            case GameStateReco.InicioReco1:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateReco.Reco1:
                Reco1.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = true;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateReco.InicioReco2:
                I1erJuego.enabled = false;
                V2doJuego.enabled = true;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateReco.Reco2:
                Reco1.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateReco.InicioReco3:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = true;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateReco.Reco3:
                Reco1.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateReco.InicioReco4:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = true;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateReco.Reco4:
                Reco1.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                N4toJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateReco.FinalReco:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = true;
                Debug.Log(currentGameState);
                break;
            default:
                currentGameState = GameStateReco.InicioReco1;
                break;

        }
        currentGameState = newGameState;



    }
    public IEnumerator FelicidadesWait(GameStateReco state)
    {
        felicitacionesImage.SetActive(true);
        yield return new WaitForSeconds(3);
        Debug.Log("salida de felicidades");
        felicitacionesImage.SetActive(false);
        ChangeGameState(state);
        Debug.Log("Este es el estado " + state);
    }
}
