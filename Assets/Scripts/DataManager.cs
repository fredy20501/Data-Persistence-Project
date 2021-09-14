using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveBestScore() {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestPlayerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadBestScore() {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }

    public string GetBestScoreInfo() {
        string bestScoreInfo = "Best Score: N/A";
        if (bestPlayerName != "") {
            bestScoreInfo = "Best Score: "+bestPlayerName+ " : "+bestScore;
        }
        return bestScoreInfo;
    }
}
