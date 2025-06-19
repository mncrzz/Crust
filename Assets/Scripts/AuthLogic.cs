using UnityEngine;
using Firebase.Auth;
using System.Threading.Tasks;
using TMPro;

public class AuthLogic : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public GameObject error;
    public GameObject done;
    public string userId = "";
    private FirebaseAuth auth;
    private bool allowLoginIfHasUser = false; //Если true, то после регистрации пользователю не надобудет потом заново входить.
    public static AuthLogic Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeFirebase();
        error.SetActive(false);
        done.SetActive(false);
    }

    public void login()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        var email = emailField.text;
        var password = passwordField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsFaulted)
            {
                error.SetActive(true);
                done.SetActive(false);
                return;
            }

            if (task.IsCompleted)
            {
                error.SetActive(false);
                done.SetActive(true);
                return;
            }
        }, taskScheduler);
    }

    public void register()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        var email = emailField.text;
        var password = passwordField.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsFaulted)
            {
                error.SetActive(true);
                done.SetActive(false);
                return;
            }

            if (task.IsCompleted)
            {
                error.SetActive(false);
                done.SetActive(true);
                return;
            }
        }, taskScheduler);
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        userId = auth.CurrentUser.UserId;
        if (auth.CurrentUser != null)
        {
            if (allowLoginIfHasUser == false)
            {
                auth.SignOut();
            }
            else
            {
                error.SetActive(false);
                done.SetActive(true);
            }
        }    
    }
}