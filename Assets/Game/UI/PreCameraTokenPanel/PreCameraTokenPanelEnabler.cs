using GameStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(CanvasGroup), typeof(Animator))]
public class PreCameraTokenPanelEnabler : MonoBehaviour
{
    private List<IGameStatePublisher> _publishers;
    private CanvasGroup _panel;
    private Animator _animator;

    [Inject]
    private void Construct(List<IGameStatePublisher> publishers)
    {
        _publishers = publishers;
        _panel = GetComponent<CanvasGroup>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        foreach (var publisher in _publishers)
        {
            publisher.Started += FadeOnPanel;
            publisher.Stoped += FadeOffPanel;
        }
    }

    private void OnDisable()
    {
        foreach (var publisher in _publishers)
        {
            publisher.Started -= FadeOnPanel;
            publisher.Stoped -= FadeOffPanel;
        }
    }

    private void FadeOffPanel()
    {
        _animator.SetBool(PreCameraTokenPanelAnimator.Parameters.Visible, false);
    }

    private void FadeOnPanel()
    {
        _animator.SetBool(PreCameraTokenPanelAnimator.Parameters.Visible, true);
    }
}
