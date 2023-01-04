using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseFollowing : MonoBehaviour
{
    private Vector3 mousePos; // マウスで取得した座標
    private Vector3 objPos; // 物体の位置を表す座標

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver.gameOver == false) // プレイヤーがゲームオーバーでない場合
        {
            mousePos = Input.mousePosition; // マウスの位置を取得
            mousePos.z = 10; // マウスカーソルのz座標はカメラまでの距離を入力。
            objPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = objPos; // ゲームオブジェクトのtransform.position(位置)にオブジェクト位置の値を代入。
        }
    }
}
