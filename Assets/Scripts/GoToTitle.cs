using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    // タイトルへと戻る処理を行う。
    public void OnClickButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
