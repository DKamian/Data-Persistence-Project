using UnityEngine;
using System.IO;
using NUnit.Framework.Constraints;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int bestScore = 0;

    public string bestPlayerName;
    public string playerName;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class BestScoreData
    {
        public int score;
        public string playerName;
    }

    public void SaveData()
    {
        BestScoreData data = new BestScoreData();
        data.score = bestScore;
        data.playerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

            bestScore = data.score;
            bestPlayerName = data.playerName;
        }
    }
}
