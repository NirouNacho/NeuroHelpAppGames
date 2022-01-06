using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{

    public static AuthUIManager instance;

    [Header("References")]
    [SerializeField]
    private GameObject checkingForAccountUI;
    [SerializeField]
    private GameObject loginUI;
    [SerializeField]
    private GameObject registerUI;
    [SerializeField]
    private GameObject verifyEmailUI;
    [SerializeField]
    private TMP_Text verifyEmailText;

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ClearUI()
    {
        FirebaseManager.instance.ClearOutputs();
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        verifyEmailUI.SetActive(false);
        checkingForAccountUI.SetActive(false);
    }
    public void LogInScreen()
    {
        ClearUI();
        loginUI.SetActive(true);
    }
    public void RegisterScreen()
    {
        ClearUI();
        registerUI.SetActive(true);

    }

    public void AwaitVerification(bool _emailSent,string _email,string _output)
    {
        ClearUI();
        verifyEmailUI.SetActive(true);
        if (_emailSent)
        {
            verifyEmailText.text = $"Email de Verificacíón Enviado a tu Correo {_email} \nPorfavor abrelo y da clic en el link de verificación ";
        }
        else
        {
            verifyEmailText.text = $"Email no enviado: {_output}\nPorfavor intenta de nuevo {_email}";
        }

    }

}
