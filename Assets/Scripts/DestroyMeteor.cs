using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 隕石消去用のプログラム
public class DestroyMeteor : MonoBehaviour
{
    public float deleteTime = 5.0f; // 隕石が消去されるまでの時間

    // Start is called before the first frame update
    void Start()
    {
            Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
