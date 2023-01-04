using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class InputRecord : MonoBehaviour
{
    // 登録する名前
    public string submitName;

   // public InputField inputField;
    int FloatToInt = 100; //小数を100倍にしてINT型にした後、再び表示用にFLOAT型にする為の値。

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

    // 記録の登録を行う一連の関数
    public void SubmitRecord(float bestTime)
    {
        InputPlayerDisplayName(PlayFabLogIn.inputName);
        SubmitPlayerScore(Timer.bestTime);
    }

    public void InputPlayerDisplayName(string inputName)
    {
        // プレイヤーが入力した名前でランキングに登録する。
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
        // PlayFabにおいては小数を利用出来ない為、
        // 取得した時間に変数FloatToIntを掛けて(int)を付加する事で整数とし、
        // 更に-1を掛ける事で昇順のランキングとする。
        // Unity上に表示する際には再び小数の形に戻す。
        int score = (int)(bestTime * FloatToInt);
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // ランキングスコアの登録
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
