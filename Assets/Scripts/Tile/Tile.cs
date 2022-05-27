using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject Unit;
    public bool IsEmpty => Unit == null;
}
