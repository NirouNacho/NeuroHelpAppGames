using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameStateRep
{
    InicioRep1, Rep1, InicioRep2, Rep2, InicioRep3, Rep3, FinalRep//, FinalScore
}

public class GameManagerRepeticion : MonoBehaviour
{
    public GameStateRep currentGameState = GameStateRep.InicioRep1;
    private static GameManagerRepeticion sharedInstance;
    public GameObject felicitacionesImage;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManagerRepeticion GetInstance()
    {
        return sharedInstance;
    }

    public void StartGame()

    {

        Rep1.GetInstance().StartRep1Game();
        Rep2.GetInstance().StartRep2Game();


        //LevelGenerator.sharedInstance.createInitialBlocks();
        //PlayerController.GetInstance().StartGame();
        //ChangeGameState(currentGameState = GameState.InGame);
        //ViewInGame.GetInstance().ShowHighestScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Rep1.GetInstance().StartRep1Game();
        //Rep2.GetInstance().StartRep2Game();
        Rep3.GetInstance().StartRep3Game();
        //currentGameState = GameState.InicioImgGame;
        //Poner aqui la fase inicial del canvas
        //I1erJuego.enabled = true;
        //V2doJuego.enabled = false;
        //N3erJuego.enabled = false;
        //Final.enabled = false;
        //this.GetComponent<ImageGame>().enabled = false;
        //this.GetComponent<VowelGame>().enabled = false;
        //this.GetComponent<NumberGame>().enabled = false;
        //Debug.Log(currentGameState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeGameState(GameStateRep newGameState)
    {

        switch (newGameState)
        {
            case GameStateRep.InicioRep1:
                //I1erJuego.enabled = false;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRep.Rep1:
                //ImageGame.GetInstance().SearchObjPhrase.SetActive(true);
                //I1erJuego.enabled = true;
                //V2doJuego.enabled = false;
                //N3erJuego.enabled = false;
                //Final.enabled = false;
                //Debug.Log(currentGameState);
                break;
            
            default:
                currentGameState = GameStateRep.InicioRep1;
                break;

        }
        currentGameState = newGameState;

    }

    public IEnumerator FelicidadesWait(GameStateRep state)
    {
        felicitacionesImage.SetActive(true);
        yield return new WaitForSeconds(3);
        Debug.Log("salida de felicidades");
        felicitacionesImage.SetActive(false);
        ChangeGameState(state);
        Debug.Log("Este es el estado " + state);
    }

}
