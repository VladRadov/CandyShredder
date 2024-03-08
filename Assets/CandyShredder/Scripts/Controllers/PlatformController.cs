using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController
{
    private PlatformView _platformView;
    private Platform _platform;

    public PlatformController(PlatformView platformView)
    {
        _platformView = platformView;
        _platform = new Platform(_platformView.StartPositionX);
    }

    public void Initialize()
    {
        _platformView.SubscribeOnInputs(_platform.UpdateXPosition);
        _platform.OnUpdatePositionEventHandler.AddListener(_platformView.UpdatePosition);
    }
}
