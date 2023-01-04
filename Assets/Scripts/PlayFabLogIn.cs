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
��PlayFab���p�̎Q�l�Ƃ����Ē������L���Q�̃T�C�g�l

PlayFab�}�X�^�[�ւ̓��bPlayFab���w�K���������Ȃ���
https://playfab-master.com/

�yPlayFab�z�v���C���[���iDisplayName�j��o�^�E�X�V�yUnity�z | Makihiro��devlog
https://mackysoft.net/playfab-update-display-name/

*/
