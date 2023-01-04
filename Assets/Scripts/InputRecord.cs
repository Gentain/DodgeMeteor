using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class InputRecord : MonoBehaviour
{
    public string submitName;
   // public InputField inputField;
    int FloatToInt = 100; //小数を100倍にしてINT型にした後、再び表示用にFLOAT型にする。

    // Start is called before the first frame update
    void Start()
    {
      //  inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InputName()
    {
        //submitName = inputField.text;
        Debug.Log(submitName);
    }

    public void SubmitRecord(float bestTime)
    {
        InputPlayerDisplayName(PlayFabLogIn.inputName);
        SubmitPlayerScore(Timer.bestTime);
    }

    public void InputPlayerDisplayName(string inputName)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = inputName
            },
            result => {
                Debug.Log("名前を入力しました！");
            },
            error => {
                Debug.Log("何か予想外のエラーが起こりました。");
            }
            );
    }

    public void SubmitPlayerScore(float bestTime)
    {
        int score = (int)(bestTime * FloatToInt);
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "SurvivingTime",
                    Value = score
                }
            }
        }, result =>
        {
            Debug.Log($"やったぜ！！スコアの送信成功!!!!!　スコア：{score}");
        }, error =>
        {
            Debug.Log("ざんねん…スコアが送信できなかったよ(´；ω；｀)ﾌﾞﾜｯ");
        });
    }
}

/*
★PlayFab利用の参考とさせて頂いた記事群のサイト様

PlayFabマスターへの道｜PlayFabを学習したいあなたへ
https://playfab-master.com/

【PlayFab】プレイヤー名（DisplayName）を登録・更新【Unity】 | Makihiroのdevlog
https://mackysoft.net/playfab-update-display-name/

*/
