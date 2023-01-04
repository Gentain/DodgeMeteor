using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{ 
    static public bool gameOver = false;
    public bool rankingGet;
    public Text bestTimeText; // 時間のテキスト
    public Text deadText; // プレイヤーがやられた時のテキスト
    public Text rankingText; // ランキング表示用のテキスト
    public Text nameText; // プレイヤー名表示用のテキスト
    public GameObject titleButton; // やり直しボタンのオブジェクト取得
    public GameObject rankingSystem;

    // Start is called before the first frame update
    void Start()
    {
      
        rankingText.text = "";
        rankingGet = false;
        gameOver = false;
        rankingSystem.SetActive(false);
    }

    static public void GameOverFlag()
    {
        gameOver = true;
    }

    private void Update()
    {
        if (gameOver == true)
        {
            rankingSystem.SetActive(true);
            nameText.text = "名前: "  + PlayFabLogIn.inputName;
            bestTimeText.text = "生存時間: " + Timer.bestTime.ToString("F2") + "s";
            deadText.text = "GAME OVER";
            titleButton.SetActive(true);
            GetRanking();
        }
        else if (gameOver == false)
        {
            nameText.text = "";
            bestTimeText.text = "";
            deadText.text = "";
            titleButton.SetActive(false);
            rankingSystem.SetActive(true);
        }
    }

    public void GetRanking()
    {
        if (rankingGet == false)
        {
            rankingText.text += "Best Time\n";
            PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
            {
                StatisticName = "SurvivingTime"
            }, result =>
            {
                foreach (var item in result.Leaderboard)
                {
                    rankingText.text += $"{ item.Position + 1}: {item.DisplayName}  {item.StatValue * 0.01f}s" + "\n";
                }
            }, error =>
            {
                Debug.Log("ざんねん！わたしのランキングしゅとくはここでおわってしまった！");
            }
                );
            rankingGet = true;
        }
    }
}

/*
★PlayFab利用の参考とさせて頂いた記事群のサイト様

PlayFabマスターへの道｜PlayFabを学習したいあなたへ
https://playfab-master.com/

【PlayFab】プレイヤー名（DisplayName）を登録・更新【Unity】 | Makihiroのdevlog
https://mackysoft.net/playfab-update-display-name/

*/
