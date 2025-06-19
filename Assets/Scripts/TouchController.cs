using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraController _CameraLook;
    void Start()
    {
        
    }

    
    void Update()
    {
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
    }
}
