using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

public class LayerSorter : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public TilemapRenderer[] tilemaps;

    void LateUpdate()
    {
        var orderedSprites = sprites.OrderBy(sprite => sprite.transform.position.z);
        var z = 0;
        foreach (var sprite in orderedSprites)
        {
            sprite.sortingOrder = -z;
            z++;
        }

        var orderedTilemaps = tilemaps.OrderBy(tilemap => tilemap.transform.position.z);
        var z1 = 0;
        foreach (var tilemap in orderedTilemaps)
        {
            tilemap.sortingOrder = -z1;
            z++;
        }
                


    }
}
