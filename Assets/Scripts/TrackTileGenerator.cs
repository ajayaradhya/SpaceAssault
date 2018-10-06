using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTileGenerator : MonoBehaviour {

    [SerializeField] GameObject firstTile;
    [SerializeField] GameObject secondTile;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject player;

    private float tileDepth;

    void Start()
    {
        tileDepth = firstTile.transform.position.z;
    }

    void Update()
    {
        print(player.transform.position.z + " ------ "+ firstTile.transform.position.z + tileDepth);
        if (player.transform.position.z > firstTile.transform.position.z + tileDepth)
        {
            print("creating..");

            var currentFirstTile = firstTile;
            firstTile = secondTile;
            Destroy(currentFirstTile);

            var newTilePosition = new Vector3(firstTile.transform.position.x, firstTile.transform.position.y, firstTile.transform.position.z + 2 * tileDepth);
            GameObject newTile = Instantiate(tilePrefab, newTilePosition, Quaternion.identity);
            newTile.transform.SetParent(firstTile.transform.parent);

            secondTile = newTile;
        }
    }
}
