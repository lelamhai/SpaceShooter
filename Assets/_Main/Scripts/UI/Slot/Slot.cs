using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private AttributeSlot _attributeISlot;

    public AttributeSlot _AttributeISlot
    {
        get => _attributeISlot;
        set => _attributeISlot = value;
    }
}