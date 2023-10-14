using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LayerSorter : MonoBehaviour
{
    public SpriteRenderer[] sprites;

    void LateUpdate()
    {
        var orderedSprites = sprites.OrderBy(sprite => sprite.transform.position.z);
        var z = 0;
        foreach (var sprite in orderedSprites)
        {
            sprite.sortingOrder = -z;
            z++;
        }
                


    }
}
