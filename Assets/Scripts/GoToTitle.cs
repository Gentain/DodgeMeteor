using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    // �^�C�g���ւƖ߂鏈�����s���B
    public void OnClickButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
