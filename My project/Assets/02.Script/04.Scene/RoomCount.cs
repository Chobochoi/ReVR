using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCount : MonoBehaviour
{
    public int count;

    public void Selected()
    {
        switch (count)
        {
            case 0:
                Data.count = 0;
                break;
            case 1:
                Data.count = 1;
                break;
            case 2:
                Data.count = 2;
                break;
            case 3:
                Data.count = 3;
                break;
        }
    }
}
