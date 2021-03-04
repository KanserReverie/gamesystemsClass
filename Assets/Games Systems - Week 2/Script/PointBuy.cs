using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointBuy : MonoBehaviour
{

    public int statBank = 10;
    public int stat1, stat2, stat3, stat4, stat5, stat6;
    public TextMeshProUGUI bankText;
    public TextMeshProUGUI stat1text, stat2text, stat3text, stat4text, stat5text, stat6text;

    public void AddPoint(int stat)
    {

        if (statBank <= 0)
            return;

        bankText.text = (statBank - 1).ToString();
        switch (stat)
        {
            case 1:
                stat1++;
                stat1text.text = stat1.ToString();
                statBank--;
                break;
            case 2:
                stat2++;
                stat2text.text = stat2.ToString();
                statBank--;
                break;
            case 3:
                stat3++;
                stat3text.text = stat3.ToString();
                statBank--;
                break;
            case 4:
                stat4++;
                stat4text.text = stat4.ToString();
                statBank--;
                break;
            case 5:
                stat5++;
                stat5text.text = stat5.ToString();
                statBank--;
                break;
            case 6:
                stat6++;
                stat6text.text = stat6.ToString();
                statBank--;
                break;
            default:
                break;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
