﻿using UnityEngine;

public class UIView : IUserInterfaceView
{
    private readonly Screens _screens;

    public UIView(Screens screens)
    {
        _screens = screens;
    }

    public Vector2 TouchPosition => _screens.HUD.TouchScreen.TouchPosition;
}
