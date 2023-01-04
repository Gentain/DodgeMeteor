using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText; // ���Ԃ̃e�L�X�g
    private float time; // �o�ߎ��Ԃ̐��l
    static public float bestTime; // �x�X�g�^�C���L�^�̒l

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.gameOver == false)
        {
            CountingTime();
        }
        else if (GameOver.gameOver == true)
        {
            bestTime = time;
        }
    }

    void CountingTime()
    {
        time += Time.deltaTime;

        // �^�C���̕\�����X�V
        timeText.text = "��������: " + time.ToString("F2") + "s";
    }
}
