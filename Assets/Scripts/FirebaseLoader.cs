using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections.Generic;
using System;

public class FirebaseLoader : MonoBehaviour {
    public void LoadData()
    {
        StartCoroutine(LoadPlayerDataCoroutine());
    }

    IEnumerator LoadPlayerDataCoroutine() {
        // Инициализация Firebase
        var dependencyTask = FirebaseApp.CheckAndFixDependenciesAsync();
        yield return new WaitUntil(() => dependencyTask.IsCompleted);

        if (dependencyTask.Result != DependencyStatus.Available) {
            Debug.LogError("Firebase error: " + dependencyTask.Result);
            yield break;
        }

        // Загрузка данных
        DatabaseReference db = FirebaseDatabase.DefaultInstance
            .GetReference($"users/{AuthLogic.Instance.userId}/playerData");

        var loadTask = db.GetValueAsync();
        yield return new WaitUntil(() => loadTask.IsCompleted);

        if (loadTask.IsFaulted) {
            Debug.LogError("Load failed: " + loadTask.Exception);
        }
        else if (loadTask.Result.Value == null) {
            Debug.Log("No data found");
        }
        else {
            // Обработка данных
            DataSnapshot snapshot = loadTask.Result;
            Dictionary<string, object> playerData = (Dictionary<string, object>)snapshot.Value;

            // Применяем данные к PlayerPrefs
            PlayerPrefs.SetFloat("sens", float.Parse((playerData["sens"]).ToString()));
            Sens_Save.Instance.slider.value = float.Parse((playerData["sens"]).ToString());
            PlayerPrefs.SetString("nickname", playerData["nickname"].ToString());
            
            Debug.Log("Data loaded successfully!");
        }
    }
}