﻿using Appsulove.Settings;

public interface IApplicationPresenter
{
    void Update();
}

public class ApplicationPresenter : IApplicationPresenter
{
    private readonly IGameplayView _gameplayView;
    private readonly IUserInterfaceView _interfaceView;
    private readonly IApplicationModel _model;
    private readonly Screens _screens;
    private readonly GameSettings _settings;

    public ApplicationPresenter(IGameplayView gameplayView, IUserInterfaceView uIView, IApplicationModel model, Screens screens, GameSettings settings)
    {
        _gameplayView = gameplayView;
        _interfaceView = uIView;
        _model = model;
        _screens = screens;
        _settings = settings;
    }

    void IApplicationPresenter.Update()
    {
        //TODO: put movement in FixedUpdate
        _gameplayView.Update(_interfaceView.TouchPosition);

        _interfaceView.Update(_model.Score, _model.Distance);
        _model.Update(_gameplayView.AddScore, _gameplayView.AddDistance);
    }
}