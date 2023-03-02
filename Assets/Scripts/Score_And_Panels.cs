using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score_And_Panels : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsGameOver=false, IsGamePlay = false;
    public static int Retry,LiveScore=0;
    [SerializeField] List<GameObject> AnimyList;
    [SerializeField] GameObject PlayPanel, GameOverpanel, HomePanel;
    [SerializeField] TextMeshProUGUI BestScore,LiveScore_Playanel,LiveScore_G_OverPanel;
    void Start()
    {
        PlayPanel.SetActive(false);
        HomePanel.SetActive(false);
        GameOverpanel.SetActive(false);
       
        if (Retry != 0)
        {
            PlayPanel.SetActive(true);
            StartCoroutine(Animi1Fire());
        }
        else {
            HomePanel.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        LiveScore_Playanel.text=LiveScore.ToString();
        LiveScore_G_OverPanel.text= "SCORE:" + LiveScore.ToString();
        BestScore.text="BEST:"+PlayerPrefs.GetInt("best").ToString();

    }
    private IEnumerator Animi1Fire()
    {

        while (true)
        {

            yield return new WaitForSeconds(1f);
            if (IsGamePlay) {
                for (int i = 0; i < AnimyList.Count; i++)
                {

                    AnimyList[i].GetComponent<AnimyFire>().IsFire = false;
                }
                AnimyList[Random.Range(0, AnimyList.Count)].GetComponent<AnimyFire>().IsFire = true;


                if (IsGameOver)
                {

                    break;
                }
            }
           

        }

    }
    public void GameStart() {
        MySounds.Instance.OnButtonTap();
        HomePanel.SetActive(false);
        PlayPanel.SetActive(true);
        StartCoroutine(Animi1Fire());
        LiveScore = 0;
        IsGamePlay =true;
        IsGameOver =false;
    }
    public void RetryGame() {
        MySounds.Instance.OnButtonTap();
        IsGamePlay = true;
        IsGameOver = false;
       
        LiveScore = 0;
        Retry++;
        SceneManager.LoadScene(0);
    } public void Home()
    {
        MySounds.Instance.OnButtonTap();
        IsGamePlay = false;
        IsGameOver = false;
       
        Retry=0;
        LiveScore = 0;
        SceneManager.LoadScene(0);
    }
}
