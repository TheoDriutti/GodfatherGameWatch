using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCarController : MonoBehaviour
{
    private static TCarController _instance;
    public static TCarController i { get { return _instance;} }

    [Tooltip("the number of frames between 2 moves on a column ; 1 is fast, 3 is slow")]
    public int speed;

    public int oilSpeed; 

    [Tooltip("the number of frames between 2 car spawns")]
    public int spawnRate;

    public TGrid carGrid;
    public TGrid strollerGrid;
    public Transform oilyLaneGrid;

    //

    private int _spawnRow = 5;

    private int[] serie = new int[] { 1, 2, 3, 4 };
    private int serieSpawnIndex = 0;
    private int serieCounter = 1;

    private int _lastCarSpawnFrame = 0;

    private int[] _lastMoveFrames = new int[4];

    public enum LaneState
    {
        Normal,
        Oily
    };
    private LaneState[] _laneStates = new LaneState[] { LaneState.Normal, LaneState.Normal, LaneState.Normal, LaneState.Normal };
    [HideInInspector] public int[] _laneVehicleCounts = new int[] { 0, 0, 0, 0 };

    //

    private void Awake()
    {
        _instance = this;
        serie = GenerateSpawnSerie();
    }

    public void UpdateCars()
    {
        int currentFrame = GameController.instance.GetCurrentFrame();
        if (_lastCarSpawnFrame + spawnRate < currentFrame)
        {
            _lastCarSpawnFrame = currentFrame;

            SpawnCar();
        }

        MoveCars();
    }

    void MoveCars()
    {
        int currentFrame = GameController.instance.GetCurrentFrame();
        // checks all the lanes
        for (int lane = 0; lane < 4; lane++)
        {
            // only if occupied
            if (_laneVehicleCounts[lane] > 0)
            {
                for (int row = 0; row < 6; row++)
                {                    
                    // finds the rows
                    if (carGrid.GetValueAt(lane, row))
                    {
                        bool isReadyToMove = _lastMoveFrames[lane] + speed < currentFrame
                                                   || (_laneStates[lane] == LaneState.Oily && _lastMoveFrames[lane] + oilSpeed < currentFrame);
                        if (isReadyToMove)
                        {
                            if (row > 0)
                            {
                                carGrid.SetValueAt(lane, row - 1);
                                carGrid.SetValueAt(lane, row, false);
                                _lastMoveFrames[lane] = currentFrame;
                            }
                            else
                            {
                                PCarMissedCondition.i.CarMissed(lane);
                                _laneVehicleCounts[lane]--;
                            }
                        }
                    }
                    if (strollerGrid.GetValueAt(lane, row))
                    {
                        bool isReadyToMove = _lastMoveFrames[lane] + speed < currentFrame
                                                   || (_laneStates[lane] == LaneState.Oily && _lastMoveFrames[lane] + oilSpeed < currentFrame);
                        if (isReadyToMove)
                        {
                            strollerGrid.SetValueAt(lane, row, false);
                            if (row > 0)
                            {
                                strollerGrid.SetValueAt(lane, row - 1);
                            }
                            _lastMoveFrames[lane] = currentFrame;
                        }
                    }

                }
            }
        }
    }

    void SpawnCar()
    {
        int spawnCol = serie[serieSpawnIndex] - 1;

        TGrid grid = carGrid;
        if (serieCounter > 2 && Random.Range(0, 4) == 0) grid = strollerGrid; // poussette 1 fois/4

        grid.SetValueAt(spawnCol, _spawnRow);   
        _laneVehicleCounts[spawnCol]++;
        _lastMoveFrames[spawnCol] = GameController.instance.GetCurrentFrame();

        serieSpawnIndex++;
        if (serieSpawnIndex > 3)
        {
            MoveToNextSerie();
        }
    }

    public void MakeOily(int pos)
    {
        oilyLaneGrid.GetChild(pos).gameObject.SetActive(true);
        _laneStates[pos] = LaneState.Oily;
    }

    void MoveToNextSerie()
    {
        serieCounter++;
        serieSpawnIndex = 0;
        serie = GenerateSpawnSerie();

        if (serieCounter > 2)
        {
            speed = 5;
            spawnRate = 15;
        }
        if (serieCounter > 3)
        {
            spawnRate = 12;
        }
        if (serieCounter > 4)
        {
            spawnRate = 10;
        }
        if (serieCounter > 5)
        {
            speed = 4;
            oilSpeed = 3;
        }
    }

    int[] GenerateSpawnSerie()
    {
        int[] newSerie = new int[] { 1, 2, 3, 4 };

        bool isPbSerie = true;
        while (isPbSerie)
        {
            isPbSerie = false;
            for (int i = 0; i < 4; i++)
            {
                int temp = newSerie[i];
                int rand = Random.Range(i, 4);
                newSerie[i] = newSerie[rand];
                newSerie[rand] = temp;
            }

            if (newSerie[0] == serie[3])
            {
                isPbSerie = true;
            }
        }

        return newSerie;
    }
}
