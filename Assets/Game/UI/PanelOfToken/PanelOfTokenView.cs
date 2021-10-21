using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates.Phase1Space;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class PanelOfTokenView : MonoBehaviour
{
    private Animator _animator;
    private GameStates.IGameStatePublisher _takeTokenSubphase;

    [Inject]
    private void Construct(IGameStatesProvider game)
    {
        _takeTokenSubphase = game.GetGameState<TakeTokenSubphase>();

    }

    void OnEnable()
    {
        _takeTokenSubphase.Started += FadeOnPanel;
        _takeTokenSubphase.Stoped += FadeOffPanel;
    }

    void OnDisable()
    {
        _takeTokenSubphase.Started -= FadeOnPanel;
        _takeTokenSubphase.Stoped -= FadeOffPanel;
    }

    private void FadeOffPanel()
    {
        _animator.SetBool(PanelOfTokenAnimator.Parameters.Visible, false);
    }

    private void FadeOnPanel()
    {
        _animator.SetBool(PanelOfTokenAnimator.Parameters.Visible, true);
    }

    private void  Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
