using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class killCountDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Kill Count: " + EnemyHealth.getKillCount();   
    }
}
