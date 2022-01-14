using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenPresentationPanel : MonoBehaviour
{
    [SerializeField] private Image _edge;
    [SerializeField] private RawImage _picture;
    [SerializeField] private RawImage _iconographic;
    [SerializeField] private RawImage _iconographic2;

    internal void Close()
    {
        this.gameObject.SetActive(false);
    }

    internal void Launch(IToken token)
    {
        this.gameObject.SetActive(true);
        _edge.color = token.PlayerConfig.Color;
        _picture.texture = token.Data.MainTexture;
        _iconographic.texture = token.Data.IconographicTexture;
        _iconographic2.texture = token.Data.IconographicTextureRotatable;
    }
}
