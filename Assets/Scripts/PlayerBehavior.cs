using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �����_���[�̃R���|�[�l���g���擾���ă����_���[�̐F��ς���B
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 覐�("Meteor"�^�O�̕t�����I�u�W�F�N�g)�ɐG�ꂽ�ۂɁA���P�b�g��ԐF�ɕς���B
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameOver.GameOverFlag();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
    }
}
