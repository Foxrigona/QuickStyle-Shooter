using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    private TextMeshProUGUI healthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        healthDisplay = GetComponent<TextMeshProUGUI>();
        changeHealth(20, 20);
    }

    public void changeHealth(int maxHealth, int currentHealth)
    {
        healthDisplay.text = string.Format("{0}/{1}",currentHealth,maxHealth);
    }
}
