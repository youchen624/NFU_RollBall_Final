using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class E_Counter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GM.t_score = GetComponent<TextMeshProUGUI>();
        GM.av_t_score = true;
        print("signed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
