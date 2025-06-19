using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.UI;

public class FirebaseSaver : MonoBehaviour
{
    private FirebaseAuth auth;
    public void SaveData()
    {
        StartCoroutine(SavePlayerDataCoroutine());
    }

    IEnumerator SavePlayerDataCoroutine() {
        // Инициализация Firebase
        var dependencyTask = FirebaseApp.CheckAndFixDependenciesAsync();
        yield return new WaitUntil(() => dependencyTask.IsCompleted);
        
        if (dependencyTask.Result != DependencyStatus.Available) {
            Debug.LogError("Firebase error: " + dependencyTask.Result);
            yield break;
        }
        // Используйте явное указание URL:
        FirebaseApp app = FirebaseApp.DefaultInstance;
        FirebaseDatabase database = FirebaseDatabase.GetInstance(app, "https://crust-3358a-default-rtdb.europe-west1.firebasedatabase.app/");

        // Подготовка данных
        var playerData = new Dictionary<string, object> {
            {"sens", PlayerPrefs.GetFloat("sens")},
            {"nickname", PhotonNetwork.NickName}
        };

        // Сохранение
        DatabaseReference db = FirebaseDatabase.DefaultInstance.RootReference;
        var saveTask = db.Child("users").Child(AuthLogic.Instance.userId).SetValueAsync(playerData);
        yield return new WaitUntil(() => saveTask.IsCompleted);

        if (saveTask.IsFaulted) {
            Debug.LogError("Save failed: " + saveTask.Exception);
        } else {
            Debug.Log("Data saved successfully!");
        }
    }
}