using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    // 隕石を生み出すジェネレーターのプログラム
    public float generateLength = 5f; // 生み出す範囲(x軸)
    public GameObject obj; 
    public float interval = 3.0f; // 隕石生成のインターバル時間

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム中は隕石の生成を繰り返す。
        InvokeRepeating("SpawnObj", 0.1f, interval);
    }

    // 隕石を生み出す関数。x軸の数値のみgenerateLengthで調整する。
    void SpawnObj()
    {
        Instantiate(obj, new Vector3(Random.Range(-generateLength, generateLength), transform.position.y, transform.position.z),
            transform.rotation);
    }
}
