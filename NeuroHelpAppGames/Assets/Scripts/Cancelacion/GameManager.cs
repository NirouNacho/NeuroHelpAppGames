using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    InicioImgGame, ImgGame, InicioVowelGame, VowelGame, InicioNumberGame, NumberGame, Final//, FinalScore
}

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.ImgGame;
    private static GameManager sharedInstance;
    public GameObject felicitacionesImage;
    public Canvas I1erJuego;
    public Canvas V2doJuego;
    public Canvas N3erJuego;
    public Canvas Final;


    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager GetInstance()
    {
        return sharedInstance;
    }


    // Start is called before the first frame update


    // Starts our game
   
    public void StartGame()

    {

        ImageGame.GetInstance().StartImageGame();
        //LevelGenerator.sharedInstance.createInitialBlocks();
        //PlayerController.GetInstance().StartGame();
        //ChangeGameState(currentGameState = GameState.InGame);
        //ViewInGame.GetInstance().ShowHighestScore();
    }


    private void Start()
    {
        //StartGame();
        currentGameState = GameState.InicioImgGame;
        I1erJuego.enabled = true;
        V2doJuego.enabled = false;
        N3erJuego.enabled = false;
        Final.enabled = false;
        this.GetComponent<ImageGame>().enabled=false;
        this.GetComponent<VowelGame>().enabled = false;
        this.GetComponent<NumberGame>().enabled = false;
        Debug.Log(currentGameState);
    }

    // Update is called once per frame
    void Update()
    {
        //Aqui manejo los estados
    }

    // Called when palyer dies
    public void GameOver()
    {
       
      //  ChangeGameState(GameState.GameOver);
        
    }
    //Called when player quit the game and go to the main menu
    public void BackToMainMenu()
    {
    //    ChangeGameState(GameState.Menu);
    }

    public void RepeatGames()
    {
        ChangeGameState(GameState.ImgGame);
        this.GetComponent<ImageGame>().enabled = true;
    }

    public void StartImageGame()
    {
        ChangeGameState(GameState.InicioImgGame);
        this.GetComponent<ImageGame>().enabled = true;


    }

    public void StartVowelGame()
    {

        ChangeGameState(GameState.VowelGame);
        this.GetComponent<VowelGame>().enabled = true;
        //GameManager.GetInstance().StartVowelGame();
    }

    public void StartNumberGame()
    {

        ChangeGameState(GameState.NumberGame);
        this.GetComponent<NumberGame>().enabled = true;
        //GameManager.GetInstance().StartVowelGame();
    }


    private void ChangeGameState(GameState newGameState)
    {
        
        switch (newGameState)
        {
            case GameState.InicioImgGame:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameState.ImgGame:
                ImageGame.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = true;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameState.InicioVowelGame:
                I1erJuego.enabled = false;
                V2doJuego.enabled = true;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameState.VowelGame:
                VowelGame.GetInstance().SearchObjPhrase.SetActive(true);
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameState.InicioNumberGame:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = true;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;
            case GameState.NumberGame:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = false;
                Debug.Log(currentGameState);
                break;

            case GameState.Final:
                I1erJuego.enabled = false;
                V2doJuego.enabled = false;
                N3erJuego.enabled = false;
                Final.enabled = true;
                Debug.Log(currentGameState);
                break;
            default:
                currentGameState = GameState.InicioImgGame;
                break;

        }
        currentGameState = newGameState;
        
    }

    

    public IEnumerator FelicidadesWait(GameState state)
    {
        felicitacionesImage.SetActive(true);
        yield return new WaitForSeconds(3);
        Debug.Log("salida de felicidades");
        felicitacionesImage.SetActive(false);
        ChangeGameState(state);
        Debug.Log("Este es el estado " + state);
    }

}
