using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOkClicked()
    {
        gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
    }
}
