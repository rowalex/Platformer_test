using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public TextMeshProUGUI tokenstxt;
    private int _max;
    private int _curr;

    public TextMeshProUGUI timetxt;
    private float _time = 0;

    public bool _running = true;
    
    public void SetTokens(int max , int curr)
    {
        _max = max;
        _curr = curr;
    }

    private void Awake()
    {
        SetText();
    }

    public void Update()
    {
        if (_running)
        _time += Time.deltaTime;
        SetText();
    }

    private void SetText()
    {
        tokenstxt.text = _curr + "/"+ _max;
        timetxt.text = _time.ToString() + "\n\n\n\n";
    }
}
