using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/TokenData")]
public class TokenData : ScriptableObject
{
    [SerializeField]
    private Texture2D _mainTexture;
    public Texture2D MainTexture => _mainTexture;

    [SerializeField]
    private Texture2D _iconographicTexture;
    public Texture2D IconographicTexture => _iconographicTexture;

    [SerializeField]
    private Texture2D _iconographicTextureRotatable;
    public Texture2D IconographicTextureRotatable => _iconographicTextureRotatable;
}
