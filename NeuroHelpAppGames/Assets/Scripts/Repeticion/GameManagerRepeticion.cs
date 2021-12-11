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
    public Canvas I1erJuego;
    public Canvas V2doJuego;
    public Canvas N3erJuego;
    public Canvas Final;

    public Text topText;

    public AudioSource aplausos;

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
    private void Start()
    {


        //Rep1.GetInstance().StartRep1Game();
        //Rep2.GetInstance().StartRep2Game();
        //Rep3.GetInstance().StartRep3Game();
        currentGameState = GameStateRep.InicioRep1;
        //Canvas 
        I1erJuego.enabled = true;
        V2doJuego.enabled = false;
        N3erJuego.enabled = false;
        Final.enabled = false;
        //Scripts
        this.GetComponent<Rep1>().enabled = false;
        this.GetComponent<Rep2>().enabled = false;
        this.GetComponent<Rep3>().enabled = false;

        Debug.Log(currentGameState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepeatGames()
    {
        Rep2.GetInstance().contPrimCol = 0;
        Rep2.GetInstance().contSegCol = 0;
        Rep2.GetInstance().contTerCol = 0;
        Rep2.GetInstance().contCuarCol = 0;
        Rep2.GetInstance().contQuinCol = 0;

        ChangeGameState(GameStateRep.Rep1);
        this.GetComponent<Rep1>().enabled = true;
    }

    public void StartRep1Game()
    {
        ChangeGameState(GameStateRep.InicioRep1);
        this.GetComponent<Rep1>().enabled = true;


    }

    public void StartRep2Game()
    {

        ChangeGameState(GameStateRep.Rep2);
        this.GetComponent<Rep2>().enabled = true;
        //GameManager.GetInstance().StartVowelGame();
    }

    public void StartRep3Game()
    {

        ChangeGameState(GameStateRep.Rep3);
        this.GetComponent<Rep3>().enabled = true;
        //GameManager.GetInstance().StartVowelGame();
    }


    private void ChangeGameState(GameStateRep newGameState)
    {

        switch (newGameState)
        {
            case GameStateRep.InicioRep1:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                topText.text = "Toca solo las figuras que se repiten en cada fila";
                Debug.Log(currentGameState);
                break;
            case GameStateRep.Rep1:
                Rep1.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = true;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameStateRep.InicioRep2:
                I1erJuego.enabled = false;
                V2doJuego.enabled = true;
                N3erJuego.enabled = false;
                Final.enabled = false;
                topText.text = "Toca solo las figuras que se repiten en cada columna";
                Debug.Log(currentGameState);
                break;
            case GameStateRep.Rep2:
                Rep2.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateRep.InicioRep3:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = true;
                Final.enabled = false;
                topText.text = "Toca solo las figuras que se repiten la tabla";
                Debug.Log(currentGameState);
                break;
            case GameStateRep.Rep3:
                Rep3.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameStateRep.FinalRep:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = true;
                Debug.Log(currentGameState);
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
        aplausos.Play();
        yield return new WaitForSeconds(3);
        Debug.Log("salida de felicidades");
        felicitacionesImage.SetActive(false);
        ChangeGameState(state);
        Debug.Log("Este es el estado " + state);
    }

}
