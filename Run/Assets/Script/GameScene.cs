using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameScene : MonoBehaviour
{
    public TextMeshProUGUI second_text;

    public Button reset;
    public Button quit;
    public Button menu;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Secund());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetButto()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void MenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    private IEnumerator Secund()
    {
        int dk = 0;
        int second = 0;
        while (true)
        {
            yield return new WaitForSeconds(1);
            second += 1;
            if(second >= 60) 
            {
                second = 0;
                dk += 1;
            }
            else
            {
                second_text.text = "Second: " + second;
            }
            if (dk > 0 && second < 10)
            {
                second_text.text = "Second: " + dk + "." + "0" + second;
            }
            else if (dk > 0 && second > 10)
            {
                second_text.text = "Second: " + dk + "."  + second;
            }
            if ((60*GameManager.Instance.BestScore2_dk + GameManager.Instance.BestScore1_scn) < (60*dk + second))
            {
                GameManager.Instance.BestScore2_dk = dk;
                GameManager.Instance.BestScore1_scn = second;
                GameManager.Instance.SaveDate();
            }
        }
    }
}
