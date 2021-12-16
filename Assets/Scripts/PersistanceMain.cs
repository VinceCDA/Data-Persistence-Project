using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistanceMain : MonoBehaviour
{
    public static PersistanceMain Instance;
    public string Name;
    public int HighScore;
    public string HighScoreName;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        LoadHighScore();
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScoreName = Name;
        data.HighScore = HighScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
    }
    
}
