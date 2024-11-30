using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI bestScore_Text;
    private void Start()
    {
        bestScore_Text.text = "Best Second: " + GameManager.Instance.BestScore2_dk + "."
                                            + GameManager.Instance.BestScore1_scn + "\n"
                                            + "Best Point: " + GameManager.Instance.poin;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
