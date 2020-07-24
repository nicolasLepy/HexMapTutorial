using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{

    [SerializeField]
    private int _x, _z;

    public int x => _x;
    public int z => _z;

    public int y => -x - z;

    public HexCoordinates(int x, int z)
    {
        _x = x;
        _z = z;
    }

    public override string ToString()
    {
        return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return x.ToString() + "\n" + y.ToString() + "\n" + z.ToString();
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public static HexCoordinates FromPosition(Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;
        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x -y);

        if (iX + iY + iZ != 0)
        {
            float dX = Math.Abs(x - iX);
            float dY = Math.Abs(y - iY);
            float dZ = Math.Abs(-x - y - iZ);

            if (dX > dY && dX > dZ)
            {
                iX = -iY - iZ;
            }
            else if (dZ > dY)
            {
                iZ = -iX - iY;
            }
        }
        
        return new HexCoordinates(iX, iZ);
    }
}
