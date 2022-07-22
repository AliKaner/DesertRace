using PathCreation.Examples;
using UnityEngine;
using UnityEngine.UI;

public class MapDistance : MonoBehaviour
{
    [SerializeField] private PathFollower pathFollower;
    
    public float totalDistance;
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    private void Update()
    {
        RefreshSlider(pathFollower.distanceTravelled / totalDistance);
    }
    private void RefreshSlider(float percentage)
    {
        _slider.value = percentage ;
    }
}
