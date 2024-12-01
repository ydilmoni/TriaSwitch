
using UnityEngine;

public class GroundCollor : MonoBehaviour
{
    public enum GroundColor
    {
        Green,
        Blue,
        Red,
        Yellow,
        Pink,
        Orange,
        Joker
    }

    [SerializeField]
    private GroundColor selectedColor;

    public GroundColor GetColor() => selectedColor;
}
