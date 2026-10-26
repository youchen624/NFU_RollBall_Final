using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float mv, mh, ms = 3;
    Rigidbody rb;

    [SerializeField] private GameObject exp_init;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mv = Input.GetAxis("Vertical");
        mh= Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(mh * ms, rb.velocity.y, mv * ms);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Cube")) return;
        ++GM.score;
        print("嘉義分");

        // 爆炸+音效
        GM.playSound_exp();
        GameObject obj = Instantiate(exp_init, transform.position, Quaternion.identity);
        Destroy(obj, 2f);

        Destroy(other.gameObject);
    }
}
