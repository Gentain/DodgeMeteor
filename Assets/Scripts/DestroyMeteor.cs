using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 覐Ώ����p�̃v���O����
public class DestroyMeteor : MonoBehaviour
{
    public float deleteTime = 5.0f; // 覐΂����������܂ł̎���

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
