using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLogIn : MonoBehaviour
{
    string defaultName = "Guest"; // �f�t�H���g�̃��O�C����
    static public string inputName; // ���͂������O
    public InputField inputField; // ���O�̓��͗�

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

    public void InputName() // ���O����͗��ɓ����
    {
        inputName = inputField.text; // ���͗��̃e�L�X�g�ɓ��ꂽ���O��������B
        Debug.Log(inputName);
    }

    public void submitPlayerDisplayName()
    {
        // ���͗��̖��O���󔒂��f�t�H���g(Guest)�̂܂܂̏ꍇ�AGuest�Ƃ������O�Ń��O�C������B
        if (inputField.text == "" || inputField.text == defaultName)
        {
            inputName = defaultName;
        }
        RankingLogIn();
    }

    // PlayFab�ɂ�郉���L���O�ւ̃G���g���[(���O�C��)
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
