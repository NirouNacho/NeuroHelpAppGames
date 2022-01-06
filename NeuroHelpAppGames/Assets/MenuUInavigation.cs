using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUInavigation : MonoBehaviour
{
    public static MenuUInavigation instance;

    [Header("UI References")]
    [SerializeField]
    public GameObject entrenarGUI;
    [SerializeField]
    public GameObject juegaGUI;
    [SerializeField]
    public GameObject perfilGUI;
    [SerializeField]
    public GameObject acerdadeGUI;
    [Space(5f)]


    [Header("Botones Panel inferior")]
    [SerializeField]
    public Button Entrenar;
    [SerializeField]
    public Button Juega;
    [SerializeField]
    public Button AcercaDe;
    [SerializeField]
    public Button Perfil;
    [Space(5f)]

    [Header("TextoAyuda")]
    public TMP_Text TextAcerca;


    private ColorBlock originalColorBlock;
    private ColorBlock pressedColorBlock;

    private string atencionApp = "Esta apliación llamada Xinli, por su traduccion del chino al español 'Entrenamiento', tiene por propósito ayudar en el entrenamiento de las habilidades de atención y memoria para personas que las necesiten atravez de juegos básicos.";

    private void Awake()
    {
        originalColorBlock.normalColor = Color.white;
        pressedColorBlock.normalColor = Color.grey;
        TextAcerca.text = atencionApp;
    }

    public void CambiarEntrenarGUI(){
       
        entrenarGUI.SetActive(true);
        juegaGUI.SetActive(false);
        perfilGUI.SetActive(false);
        acerdadeGUI.SetActive(false);
        Entrenar.colors = pressedColorBlock;
        Juega.colors = originalColorBlock;
        AcercaDe.colors = originalColorBlock;
        Perfil.colors = originalColorBlock;
    }

    public void CambiarJuegaGUI()
    {

        entrenarGUI.SetActive(false);
        juegaGUI.SetActive(true);
        perfilGUI.SetActive(false);
        acerdadeGUI.SetActive(false);
        Entrenar.colors = originalColorBlock;
        Juega.colors = pressedColorBlock;
        AcercaDe.colors = originalColorBlock;
        Perfil.colors = originalColorBlock;
    }

    public void CambiarPerfilGUI()
    {

        entrenarGUI.SetActive(false);
        juegaGUI.SetActive(false);
        perfilGUI.SetActive(true);
        acerdadeGUI.SetActive(false);
        Entrenar.colors = originalColorBlock;
        Juega.colors = originalColorBlock;
        AcercaDe.colors = pressedColorBlock;
        Perfil.colors = originalColorBlock;
    }


    public void CambiarAcercadeGUI()
    {

        entrenarGUI.SetActive(false);
        juegaGUI.SetActive(false);
        perfilGUI.SetActive(false);
        acerdadeGUI.SetActive(true);
        Entrenar.colors = originalColorBlock;
        Juega.colors = originalColorBlock;
        AcercaDe.colors = originalColorBlock;
        Perfil.colors = pressedColorBlock;
    }


    public void SetAyudaAppText()
    {

    }


}
