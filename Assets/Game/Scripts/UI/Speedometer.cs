using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    public void RefreshText(float newText)
    {
        text.text = Mathf.CeilToInt(newText).ToString();
    }
    
    public void TextColorChange(Color color)
    {
        text.color = color;
    }
}
