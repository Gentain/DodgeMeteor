using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // �Q�[���ւƐi�ށB
    public void OnClickButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}