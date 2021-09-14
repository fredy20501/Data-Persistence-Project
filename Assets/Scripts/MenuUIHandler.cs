using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;

    void Start() {
        if (DataManager.Instance != null) {
            bestScoreText.text = DataManager.Instance.GetBestScoreInfo();
        }
        else {
            bestScoreText.text = "Best Score: N/A";
        }
    }

    public void StartGame() {
        DataManager.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
