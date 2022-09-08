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

    //

    private int _spawnRow = 4;

    private int[] serie = new int[] { 1, 2, 3, 4 };
    private int serieSpawnIndex = 0;
    private int serieCounter = 1;

    private int _lastCarSpawnFrame = 0;

    private int[] _lastMoveFrames = new int[4];

    private int[] _laneStates = new int[4]; // 0 : free lane ; 1 : occupied lane ; 2 : oily lane ; 3 occupied + oily lane

    //

    private void Awake()
    {
        _instance = this;
        serie = GenerateSpawnSerie();
    }

    public void UpdateCars()
    {
        int currentFrame = TGameController.i.GetCurrentFrame();
        if (_lastCarSpawnFrame + spawnRate < currentFrame)
        {
            _lastCarSpawnFrame = currentFrame;

            SpawnCar();
        }

        MoveCars();
    }

    void MoveCars()
    {
        int currentFrame = TGameController.i.GetCurrentFrame();
        // checks all the lanes
        for (int lane = 0; lane < 4; lane++)
        {
            // only if occupied
            if (_laneStates[lane] == 1 || _laneStates[lane] == 3)
            {
                for (int row = 0; row < 5; row++)
                {
                    List<TGrid> updatedGrids = new List<TGrid>();
                    
                    // finds the rows
                    if (carGrid.GetValueAt(lane, row))
                    {
                        updatedGrids.Add(carGrid);
                    }
                    if (strollerGrid.GetValueAt(lane, row))
                    {
                        updatedGrids.Add(strollerGrid);
                    }

                    if (updatedGrids.Count > 0)
                    {
                        foreach (TGrid grid in updatedGrids)
                        {
                            bool isReadyToMove = _lastMoveFrames[lane] + speed < currentFrame
                                                || (_laneStates[lane] == 3 && _lastMoveFrames[lane] + oilSpeed < currentFrame);
                            if (isReadyToMove)
                            {
                                grid.SetValueAt(lane, row, false);
                                if (row > 1)
                                {
                                    grid.SetValueAt(lane, row - 1);
                                }
                                else
                                {
                                    grid.SetValueAt(lane, row, false);
                                    _laneStates[lane]--;
                                }
                                _lastMoveFrames[lane] = currentFrame;
                            }
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
        _laneStates[spawnCol]++;
        _lastMoveFrames[spawnCol] = TGameController.i.GetCurrentFrame();

        serieSpawnIndex++;
        if (serieSpawnIndex > 3)
        {
            MoveToNextSerie();
        }
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

        Debug.Log(newSerie[0] + "" + newSerie[1] + newSerie[2] + newSerie[3]); 
        return newSerie;
    }
}
