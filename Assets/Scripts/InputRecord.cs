using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class InputRecord : MonoBehaviour
{
    // �o�^���閼�O
    public string submitName;

   // public InputField inputField;
    int FloatToInt = 100; //������100�{�ɂ���INT�^�ɂ�����A�Ăѕ\���p��FLOAT�^�ɂ���ׂ̒l�B

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

    // �L�^�̓o�^���s����A�̊֐�
    public void SubmitRecord(float bestTime)
    {
        InputPlayerDisplayName(PlayFabLogIn.inputName);
        SubmitPlayerScore(Timer.bestTime);
    }

    public void InputPlayerDisplayName(string inputName)
    {
        // �v���C���[�����͂������O�Ń����L���O�ɓo�^����B
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = inputName
            },
            result => {
                Debug.Log("���O����͂��܂����I");
            },
            error => {
                Debug.Log("�����\�z�O�̃G���[���N����܂����B");
            }
            );
    }

    public void SubmitPlayerScore(float bestTime)
    {
        // PlayFab�ɂ����Ă͏����𗘗p�o���Ȃ��ׁA
        // �擾�������Ԃɕϐ�FloatToInt���|����(int)��t�����鎖�Ő����Ƃ��A
        // �X��-1���|���鎖�ŏ����̃����L���O�Ƃ���B
        // Unity��ɕ\������ۂɂ͍Ăя����̌`�ɖ߂��B
        int score = (int)(bestTime * FloatToInt);
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // �����L���O�X�R�A�̓o�^
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
            Debug.Log($"��������I�I�X�R�A�̑��M����!!!!!�@�X�R�A�F{score}");
        }, error =>
        {
            Debug.Log("����˂�c�X�R�A�����M�ł��Ȃ�������(�L�G�ցG�M)��ܯ");
        });
    }
}

/*
��PlayFab���p�̎Q�l�Ƃ����Ē������L���Q�̃T�C�g�l

PlayFab�}�X�^�[�ւ̓��bPlayFab���w�K���������Ȃ���
https://playfab-master.com/

�yPlayFab�z�v���C���[���iDisplayName�j��o�^�E�X�V�yUnity�z | Makihiro��devlog
https://mackysoft.net/playfab-update-display-name/

*/
