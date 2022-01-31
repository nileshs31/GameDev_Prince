using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public GameObject tile, bomb;
    public TileController TileCon;
 
    public void GreenTile()
    {   
        tile.GetComponent<SpriteRenderer>().color = Color.green;
        bomb.SetActive(false);
    }
    public void PlaceBombTop()
    {
        if (tile.GetComponent<SpriteRenderer>().color != Color.cyan)
        {
            bomb.SetActive(true);
            tile.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else
        {
            TileCon.showBombTop();
        }
    }
    public void PlaceBombBottom()
    {
        if (tile.GetComponent<SpriteRenderer>().color != Color.cyan)
        {
            bomb.SetActive(true);
            tile.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else
        {
            TileCon.showBombBottom();
        }
    }


}
