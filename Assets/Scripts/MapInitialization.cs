using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInitialization : MonoBehaviour
{

    [SerializeField] private GameObject OutsideWall;
    [SerializeField] private GameObject OutsideCorner;
    private int[,] Map;

    public int length;
    public int width;
    private float offset;

    private void Awake()
    {
        offset = 32 / OutsideWall.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

        Map = new int[length, width];
    }


    // Start is called before the first frame update
    void Start()
    {
        MapInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MapInitialize()
    {
        Map[1, 1] = -1;
        Map[1, 2] = -1;

        for(int i = 0; i < length; i++)
        {
            for(int j = 0; j < width; j++)
            {
                GameObject gO = null;
                Vector2 position = new Vector2((i - (length >> 1) + 1) * offset, (j - (width >> 1) + 1) * offset);
                switch(Map[i, j])
                {
                    case -1:
                        gO = Instantiate(OutsideWall, position, Quaternion.identity);
                        break;
                    case 0:
                        gO = Instantiate(OutsideCorner, position, Quaternion.identity);
                        break;
                }
            }
        }
    }
}
