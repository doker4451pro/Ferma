using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject GardenBed;
    [SerializeField] private int maxGarden = 10;

    private float cellX;
    private float cellY;
    private Vector3 prevMousePosition;


    private int gardenNow = 1;

    private void Awake()
    {
        cellX = tilemap.cellSize.x;
        cellY = tilemap.cellSize.y;
    }

    public void CustomOnMouseDown()
    {
        if (gardenNow <= maxGarden)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //чтобы реже вызывать
            if ((mousePosition - prevMousePosition).magnitude >= 1f)
            {

                Vector3Int worldToCell = tilemap.WorldToCell(mousePosition);
                if (CheakGroundAround(worldToCell.x, worldToCell.y))
                {
                    gardenNow++;
                    var vector = tilemap.CellToWorld(worldToCell);
                    vector.z = 0;
                    vector.y += cellY / 2;
                    Instantiate(GardenBed, vector, Quaternion.identity);
                }
                prevMousePosition = mousePosition;
            }
        }
    }

    private bool CheackGround(int x,int y) 
    {
        var vector3 = new Vector3Int(x, y, 0);

        var vector2pro = tilemap.CellToWorld(vector3);
        vector2pro.y += cellY/2;
        RaycastHit2D hit = Physics2D.Raycast(vector2pro, Vector2.zero);
        return hit.transform != null && hit.transform.GetComponent<TilemapCollider2D>();
    }

    private bool CheakGroundAround(int x,int y) 
    {
        return CheackGround(x,y) & CheackGround(x+=1,y) & CheackGround(x,y+=1) & CheackGround(x -= 1, y);
    }
}
