using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// è¦ÎÁ‹—p‚ÌƒvƒƒOƒ‰ƒ€
public class DestroyMeteor : MonoBehaviour
{
    public float deleteTime = 5.0f; // è¦Î‚ªÁ‹‚³‚ê‚é‚Ü‚Å‚ÌŠÔ

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
