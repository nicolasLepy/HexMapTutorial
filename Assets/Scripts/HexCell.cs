using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{

    [SerializeField]
    private HexCoordinates _coordinates;

    [SerializeField]
    private HexCell[] neighbors;

    public Color color { get; set; }

    public HexCoordinates coordinates
    {
        get => _coordinates;
        set => _coordinates = value;
    }

    public HexCell GetNeighbor(HexDirection direction)
    {
        return neighbors[(int) direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell neighbor)
    {
        neighbors[(int) direction] = neighbor;
        neighbor.neighbors[(int) direction.Opposite()] = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
