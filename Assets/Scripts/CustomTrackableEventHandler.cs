using Vuforia;
using UnityEngine;
using UnityEngine.UI;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler
{

    [SerializeField] Toggle toggle = null;

	protected override void OnTrackingFound()
	{
        toggle.isOn = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
	}


    protected override void OnTrackingLost()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
