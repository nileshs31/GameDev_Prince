using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public float waitTime;
    public Tiles[] tiles;
    public static int count = 0;
    public GameObject SelectedTile;
    public int index=0;
 
    void Start()
    {
        SelectTileTop();
    }
    public void SelectTileTop()
    {
        if (SelectedTile != null && SelectedTile.GetComponent<SpriteRenderer>().color != Color.cyan)
        {
            SelectedTile.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("in the if up");
        }
        index = Random.Range(0, 6);
        tiles[index].GreenTile();
        SelectedTile = tiles[index].gameObject;
    }
    public void SelectTileBottom()
    {
        if (SelectedTile != null && SelectedTile.GetComponent<SpriteRenderer>().color != Color.cyan)
        {
            SelectedTile.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("in the if down");
        }
        index = Random.Range(6, 12);
        tiles[index].GreenTile();
        SelectedTile = tiles[index].gameObject;
    }
     
    public void showBombBottom()
    {
        count = Random.Range(0, 6);
        tiles[count].PlaceBomb();
    }
    public void showBombTop()
    {
        count = Random.Range(6, 12);
        tiles[count].PlaceBomb();
    }
     

}



