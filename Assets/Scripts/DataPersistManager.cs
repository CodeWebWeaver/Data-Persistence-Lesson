using System.IO;
using UnityEngine;

public class DataPersistManager : MonoBehaviour
{

    public static DataPersistManager Instance;
    private string m_playerName;
    private int m_Points;
    

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [System.Serializable]
    public class PlayerData {
        public string name;
        public int score;
    }

    public void SaveData(int points) {

        string filepath = Path.Combine(Application.persistentDataPath, "scoreInfo.json");
        m_Points = points;

        if(File.Exists(filepath)) {
            string jsonScore = File.ReadAllText(filepath);
            PlayerData existData = JsonUtility.FromJson<PlayerData>(jsonScore);

            if (existData.score < m_Points) {
                savePlayerData(filepath);
            }
        } else {
            savePlayerData(filepath);
        }
    }

    private void savePlayerData(string filepath) {
        PlayerData playerData = new PlayerData();
        playerData.name = m_playerName;
        playerData.score = m_Points;

        string newScore = JsonUtility.ToJson(playerData);
        
        File.WriteAllText(filepath, newScore);
    }

    public int getBestScore() {
        string filepath = Path.Combine(Application.persistentDataPath, "scoreInfo.json");
        if (File.Exists(filepath)) {
            string jsonScore = File.ReadAllText(filepath);
            PlayerData existsData = JsonUtility.FromJson<PlayerData>(jsonScore);
            return existsData.score;
        }
        return 0;
    }

    public string getBestPlayername() {
        string filepath = Path.Combine(Application.persistentDataPath, "scoreInfo.json");
        if (File.Exists(filepath)) {
            string jsonScore = File.ReadAllText(filepath);
            PlayerData existsData = JsonUtility.FromJson<PlayerData>(jsonScore);
            return existsData.name;
        }
        return "";
    }

    public void setPlayerName(string playerName) {
        m_playerName = playerName;
    }
}
