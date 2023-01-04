using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseFollowing : MonoBehaviour
{
    private Vector3 mousePos; // �}�E�X�Ŏ擾�������W
    private Vector3 objPos; // ���̂̈ʒu��\�����W

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.gameOver == false) // �v���C���[���Q�[���I�[�o�[�łȂ��ꍇ
        {
            mousePos = Input.mousePosition; // �}�E�X�̈ʒu���擾
            mousePos.z = 10; // �}�E�X�J�[�\����z���W�̓J�����܂ł̋�������́B
            objPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = objPos; // �Q�[���I�u�W�F�N�g��transform.position(�ʒu)�ɃI�u�W�F�N�g�ʒu�̒l�����B
        }
    }
}
