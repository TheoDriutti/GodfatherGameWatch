using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCarController : MonoBehaviour
{
    private static TCarController _instance;
    public static TCarController i { get { return _instance;} }

    [Tooltip("the time between 2 moves on a column")]
    public int periodMin; 
    public int periodMax;

    private int[] _periodsPerColumn = new int[5];

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateCars()
    {
        
    }
}
