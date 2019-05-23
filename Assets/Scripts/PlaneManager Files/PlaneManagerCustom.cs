using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaneManagerCustom : MonoBehaviour
{

    [SerializeField] PlaneFinderBehaviour planeFinderBehaviour = null;
    [SerializeField] AnchorInputListenerBehaviour anchorInputListenerBehaviour = null;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMode(bool active)
    {
        planeFinderBehaviour.enabled = active;
        anchorInputListenerBehaviour.enabled = active;
    }
}
