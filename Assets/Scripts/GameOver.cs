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
    public Text bestTimeText; // ���Ԃ̃e�L�X�g
    public Text deadText; // �v���C���[�����ꂽ���̃e�L�X�g
    public Text rankingText; // �����L���O�\���p�̃e�L�X�g
    public Text nameText; // �v���C���[���\���p�̃e�L�X�g
    public GameObject titleButton; // ��蒼���{�^���̃I�u�W�F�N�g�擾
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
            nameText.text = "���O: "  + PlayFabLogIn.inputName;
            bestTimeText.text = "��������: " + Timer.bestTime.ToString("F2") + "s";
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
                Debug.Log("����˂�I�킽���̃����L���O����Ƃ��͂����ł�����Ă��܂����I");
            }
                );
            rankingGet = true;
        }
    }
}

/*
��PlayFab���p�̎Q�l�Ƃ����Ē������L���Q�̃T�C�g�l

PlayFab�}�X�^�[�ւ̓��bPlayFab���w�K���������Ȃ���
https://playfab-master.com/

�yPlayFab�z�v���C���[���iDisplayName�j��o�^�E�X�V�yUnity�z | Makihiro��devlog
https://mackysoft.net/playfab-update-display-name/

*/
