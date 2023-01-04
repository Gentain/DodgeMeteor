using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogIn : MonoBehaviour
{
    string defaultName = "Guest";
    static public string inputName;
    public InputField inputField;

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

    public void InputName()
    {
        inputName = inputField.text;
        Debug.Log(inputName);
    }

    public void submitPlayerDisplayName()
    {
        if (inputField.text == "" || inputField.text == defaultName)
        {
            inputName = defaultName;
        }
        RankingLogIn();
    }

    // Start is called before the first frame update
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
