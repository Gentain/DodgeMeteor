using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // レンダラーのコンポーネントを取得してレンダラーの色を変える。
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 隕石("Meteor"タグの付いたオブジェクト)に触れた際に、ロケットを赤色に変える。
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameOver.GameOverFlag();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
    }
}
