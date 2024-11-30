using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int BestScore1_scn;
    public int BestScore2_dk;
    public int poin;

    private void Awake()
    {
        LoadData();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    [SerializeField]
    class BestScore
    {
        public int best_score1_scn;
        public int best_score1_dk;
        public int point_;
    }

    public void SaveDate()
    {
        BestScore bestScore = new BestScore();
        bestScore.best_score1_scn = BestScore1_scn;
        bestScore.best_score1_dk = BestScore2_dk;
        bestScore.point_ = poin;

        string json = JsonUtility.ToJson(bestScore);

        File.WriteAllText(Application.persistentDataPath + "/run.json", json);
    }
    public void LoadData()
    {
        string peth = Application.persistentDataPath + "/run.json";
        if (File.Exists(peth))
        {
            string json = File.ReadAllText(peth);
            BestScore best_score = JsonUtility.FromJson<BestScore>(json);

            BestScore1_scn = best_score.best_score1_scn;
            BestScore2_dk = best_score.best_score1_dk;
            poin = best_score.point_;
        }
    }
}
