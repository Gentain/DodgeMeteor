using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // ゲームへと進む。
    public void OnClickButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}