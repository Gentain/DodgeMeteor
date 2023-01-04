using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogIn : MonoBehaviour
{
    string defaultName = "Guest"; // デフォルトのログイン名
    static public string inputName; // 入力した名前
    public InputField inputField; // 名前の入力欄

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = defaultName;
        inputName = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InputName() // 名前を入力欄に入れる
    {
        inputName = inputField.text; // 入力欄のテキストに入れた名前を代入する。
        Debug.Log(inputName);
    }

    public void submitPlayerDisplayName()
    {
        // 入力欄の名前が空白かデフォルト(Guest)のままの場合、Guestという名前でログインする。
        if (inputField.text == "" || inputField.text == defaultName)
        {
            inputName = defaultName;
        }
        RankingLogIn();
    }

    // PlayFabによるランキングへのエントリー(ログイン)
   public void RankingLogIn()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CustomId = inputName, CreateAccount = true },
result => Debug.Log("Login Succeeded!"),
error => Debug.Log("Login Failed"));
    }
}

/*
★PlayFab利用の参考とさせて頂いた記事群のサイト様

PlayFabマスターへの道｜PlayFabを学習したいあなたへ
https://playfab-master.com/

【PlayFab】プレイヤー名（DisplayName）を登録・更新【Unity】 | Makihiroのdevlog
https://mackysoft.net/playfab-update-display-name/

*/
