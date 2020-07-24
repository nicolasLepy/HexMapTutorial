using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{

    [SerializeField]
    private HexCoordinates _coordinates;


    public Color color { get; set; }
    
    public HexCoordinates coordinates
    {
        get => _coordinates;
        set => _coordinates = value;
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
