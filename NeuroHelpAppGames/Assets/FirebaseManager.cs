using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Analytics;
using TMPro;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager instance;

    [Header("Firebase")]
    public FirebaseAuth auth;
    public FirebaseUser user;
    [Space(5f)]

    [Header("Login References")]
    [SerializeField]
    private TMP_InputField loginEmail;
    [SerializeField]
    private TMP_InputField loginPassword;
    [SerializeField]
    private TMP_InputField loginOutputText;
    [Space(5f)]

    [Header("Register References")]
    [SerializeField]
    private TMP_InputField registerUsername;
    [SerializeField]
    private TMP_InputField registerEmail;
    [SerializeField]
    private TMP_InputField registerPassword;
    [SerializeField]
    private TMP_InputField registerConfirmPassword;
    [SerializeField]
    private TMP_InputField registerOutputText;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;

        }

    }

    private void Start()
    {
        StartCoroutine(CheckAndFixDependancies());
    }

    private IEnumerator CheckAndFixDependancies()
    {
        var CheckAndFixDependanciesTask =FirebaseApp.CheckAndFixDependenciesAsync();

        yield return new WaitUntil(predicate: () => CheckAndFixDependanciesTask.IsCompleted);

        var dependancyResult = CheckAndFixDependanciesTask.Result;

        if (dependancyResult == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
        else
        {
            Debug.LogError($"Could not resolve all Firebase dependencies: {dependancyResult}");
        }

    }

    private void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        StartCoroutine(CheckAutoLogin());
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }


    private IEnumerator CheckAutoLogin()
    {
        yield return new WaitForEndOfFrame();
        if (user != null)
        {
            var reloadTask = user.ReloadAsync();

            yield return new WaitUntil(predicate: () => reloadTask.IsCompleted);
            AutoLogin();
        }
        else
        {
            AuthUIManager.instance.LogInScreen();
        }
    }

    private void AutoLogin()
    {
        if (user != null)
        {
            if (user.IsEmailVerified)
            {
                GameManagerLogin.instance.ChangeScene(1);
            }
            else
            {
                StartCoroutine(SendVerificationEmail());
            }
            
        }
        else
        {
            
            AuthUIManager.instance.LogInScreen();
        }
    }

   
    private void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = auth.CurrentUser != user && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Sgned Out");
            }
            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log($"Signed In: {user.DisplayName}");
            }

        }

    }
    public void ClearOutputs()
    {
        loginOutputText.text = "";
        registerOutputText.text = "";
    }


    public void LoginButton()
    {
        StartCoroutine(LoginLogic(loginEmail.text, loginPassword.text));
    }

    public void RegisterButton()
    {
        StartCoroutine(RegisterLogic(registerUsername.text, registerEmail.text, registerPassword.text, registerConfirmPassword.text));
    }

    private IEnumerator LoginLogic(string _email, string _password)
    {
        Credential credential = EmailAuthProvider.GetCredential(_email, _password);

        var loginTask = auth.SignInWithCredentialAsync(credential);

        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if(loginTask.Exception != null)
        {
            FirebaseException firebaseException = (FirebaseException)loginTask.Exception.GetBaseException();
            AuthError error = (AuthError)firebaseException.ErrorCode;
            string output = "Unknown Error. Please Try Again";

            switch (error)
            {
                case AuthError.MissingEmail:
                    output = "Por favor ingresa tu email";
                    break;

                case AuthError.MissingPassword:
                    output = "Porfavor ingresa tu contraseña";
                    break;

                case AuthError.InvalidEmail:
                    output = "Por favor ingresa un email correcto";
                    break;

                case AuthError.WrongPassword:
                    output = "Contraseña incorrecta";
                    break;

                case AuthError.UserNotFound:
                    output = "La cuenta no existe";
                    break;
            }
            loginOutputText.text = output;
        }
        else
        {
            if (user.IsEmailVerified)
            {
                yield return new WaitForSeconds(1f);
                GameManagerLogin.instance.ChangeScene(1);
            }
            else
            {
                StartCoroutine(SendVerificationEmail());
            }
        }

    }

    private IEnumerator RegisterLogic(string _username, string _email, string _password, string _confirmPassword)
    {
        if (_username == "")
        {
            registerOutputText.text = "Porfavor ingresa un nombre de usuario";
        }else if (_password!=_confirmPassword)
        {
            registerOutputText.text = "Las contraseñas no coinciden!";
        }
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);
            if(registerTask.Exception != null)
            {
                FirebaseException firebaseException = (FirebaseException)registerTask.Exception.GetBaseException();
                AuthError error = (AuthError)firebaseException.ErrorCode;
                string output = "Error desconocido intenta otra vez";

                switch (error)
                {
                    case AuthError.InvalidEmail:
                        output = "Email incorrecto";
                        break;

                    case AuthError.EmailAlreadyInUse:
                        output = "Email ya está en uso";
                        break;

                    case AuthError.WeakPassword:
                        output = "Contraseña débil";
                        break;

                    case AuthError.MissingEmail:
                        output = "Porfavor ingresa tu email";
                        break;

                    case AuthError.MissingPassword:
                        output = "Porfavor ingresa tu contraseña";
                        break;
                }
                registerOutputText.text = output;
            }
            else
            {
                UserProfile profile = new UserProfile
                {
                    DisplayName = _username,

                    // Give Profile Default photo
                    PhotoUrl = new System.Uri("https://pbs.twimg.com/media/EFKdt0bWsAIfc19.jpg"),
                };

                var defaultUserTask= user.UpdateUserProfileAsync(profile);

                yield return new WaitUntil(predicate: () => defaultUserTask.IsCompleted);

                if (defaultUserTask.Exception != null)
                {
                    user.DeleteAsync();
                    FirebaseException firebaseException = (FirebaseException)defaultUserTask.Exception.GetBaseException();
                    AuthError error = (AuthError)firebaseException.ErrorCode;
                    string output = "Error desconocido. Intenta otra vez";

                    switch (error)
                    {
                        case AuthError.Cancelled:
                            output = "Actualizacion de usuario cancelada";
                            break;

                        case AuthError.SessionExpired:
                            output = "Sesion caducada";
                            break;

                    }
                    loginOutputText.text = output;
                }
                else
                {
                    Debug.Log($"Firebase User Craeted Successfully: {user.DisplayName} ({user.UserId})");

                    StartCoroutine(SendVerificationEmail());
                }

            }
        }
    }



    private IEnumerator SendVerificationEmail()
    {
        var emailTask = user.SendEmailVerificationAsync();

        yield return new WaitUntil(predicate: () => emailTask.IsCompleted);

        if(emailTask.Exception != null)
        {
            FirebaseException firebaseException = (FirebaseException)emailTask.Exception.GetBaseException();
            AuthError error = (AuthError)firebaseException.ErrorCode;

            string output = "Error desconocido, Prueba otra vez!";

            switch (error)
            {
                case AuthError.Cancelled:
                    output = "Verification Task was Cancelled";
                    break;

                case AuthError.InvalidRecipientEmail:
                    output = "Correo Invalido";
                    break;
                case AuthError.TooManyRequests:
                    output = "Demasiadas peticiones , intenalo despues";
                    break;
            }

            AuthUIManager.instance.AwaitVerification(false, user.Email, output);

        }
        else
        {
            AuthUIManager.instance.AwaitVerification(true, user.Email, null);
            Debug.Log("Correo enviado Satisfactoriamente");
        }
    }


    public void UpdateProfilePicture(string _newPfpURL)
    {
        StartCoroutine(UpdateProfilePictureLogic( _newPfpURL));
    }


    private IEnumerator UpdateProfilePictureLogic(string _newPfpURL)
    {
        if(user != null)
        {
            UserProfile profile = new UserProfile();

            try
            {
                UserProfile _profile = new UserProfile
                {
                    PhotoUrl = new System.Uri(_newPfpURL),
                };

                profile = _profile;
            }
            catch
            {

                LobbyManager.instance.Output("Error descargando la imagen, Asegurate de que el enlace es valido");
                yield break;
            
            }

            var pfpTask = user.UpdateUserProfileAsync(profile);
            yield return new WaitUntil(predicate: () => pfpTask.IsCompleted);
            
            if(pfpTask.Exception != null)
            {
                Debug.LogError($"Updating Profile Picture was unsuccesful:{pfpTask.Exception}");
            }
            else
            {
                LobbyManager.instance.ChangePfpSucces();
                Debug.Log("Profile Image updated Succesfully");

            }
        }
    }

}
