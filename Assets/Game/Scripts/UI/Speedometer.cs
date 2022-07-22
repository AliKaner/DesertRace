using PathCreation.Examples;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PathFollower pathFollower;

    public void RefreshText()
    {
        if (pathFollower.speed < 0)
        {
            text.text = "0";
            return;
        }

        text.text = Mathf.FloorToInt(pathFollower.speed).ToString();
    }

    public void SetSpeedometerColor(Color givenColor)
    {
        text.color = givenColor;
    }
}