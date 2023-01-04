using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText; // 時間のテキスト
    private float time; // 経過時間の数値
    static public float bestTime; // ベストタイム記録の値

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // プレイ中は常に時間計測をし、ゲームオーバーになった際はベストタイムを取得する。
    void Update()
    {
        if (GameOver.gameOver == false)
        {
            CountingTime();
        }
        else if (GameOver.gameOver == true)
        {
            bestTime = time;
        }
    }

    void CountingTime()
    {
        time += Time.deltaTime;

        // タイムの表示を更新
        timeText.text = "生存時間: " + time.ToString("F2") + "s";
    }
}
