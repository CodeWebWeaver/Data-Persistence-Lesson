using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManuScript : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public TMP_InputField inputField; // Поле ввода
    public Button startButton;     // Кнопка "Старт"
    void Start()
    {
        bestScoreText.text = "Best Score : "
        + DataPersistManager.Instance.getBestPlayername()
        + " : " 
        + DataPersistManager.Instance.getBestScore();
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame() {
        DataPersistManager.Instance.setPlayerName(inputField.text);
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        if (Application.isPlaying)
        {
            Application.Quit();
        }
    #endif
    }

}
