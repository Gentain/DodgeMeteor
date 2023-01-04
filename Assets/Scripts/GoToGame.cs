using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // ÉQÅ[ÉÄÇ÷Ç∆êiÇﬁÅB
    public void OnClickButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}