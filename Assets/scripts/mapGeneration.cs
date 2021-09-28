using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Tilemap))]
public class mapGeneration : MonoBehaviour
{
  [SerializeField]private Tile[] tiles;
  [SerializeField]private Transform camPos;
  [SerializeField]private int generationRange = 30;
  private Tilemap mapTileMap;

  void Awake(){
    mapTileMap = GetComponent<Tilemap>();

    //error message
    if (!mapTileMap)
      Debug.LogError("can't get tilemap");
  }

  void Start(){;
    for (int x=0; x!=20; x++) {
      SetTile(x, 1, tiles[1]);
    }
  }

    // Update is called once per frame
    void Update()
    {
      int camX = Mathf.RoundToInt(Mathf.Floor(camPos.position.x));
      Generate(camX);
    }

    public void Generate(int camX){
      //deleating distant tiles
      for (int y=-5; y<=4; y++) {
        mapTileMap.SetTile(new Vector3Int(camX-2,y,0), null);
        mapTileMap.SetTile(new Vector3Int(camX-3,y,0), null);
        mapTileMap.SetTile(new Vector3Int(camX-4,y,0), null);
      }

      // basic genration
      for (int x=camX; x!=camX + generationRange; x++) {
          if (mapTileMap.GetTile(new Vector3Int(x,1,0))) {
              continue;
          } else if(Random.Range(0, 4)!=1){
            SetTile(x, 1, tiles[1]);
          } else {
            SetTile(x, 1, tiles[3]);
          }
        }

        //edges
      for (int x=camX; x!=camX + generationRange; x++) {
        // edges generation
        if (mapTileMap.GetTile(new Vector3Int(x,1,0))== tiles[3]) {
          if (mapTileMap.GetTile(new Vector3Int(x-1,1,0))== tiles[1]) {
            SetTile(x-1, 1, tiles[2]);
          } else if (mapTileMap.GetTile(new Vector3Int(x+1,1,0))== tiles[1]) {
            SetTile(x+1, 1, tiles[0]);
          }
        }

        //edges fixing
        if (mapTileMap.GetTile(new Vector3Int(x,1,0)) == tiles[0]) {
          if (mapTileMap.GetTile(new Vector3Int(x-1,1,0)) == tiles[3] && mapTileMap.GetTile(new Vector3Int(x+1,1,0)) == tiles[3]) {
            SetTile(x, 1, tiles[3]);
            SetTile(x, 0, tiles[3]);
          }
          if (mapTileMap.GetTile(new Vector3Int(x-1,1,0)) == tiles[2]) {
            SetTile(x, 1, tiles[3]);
            SetTile(x, 0, tiles[3]);
          }
        }
        
        if (mapTileMap.GetTile(new Vector3Int(x,1,0)) == tiles[2]) {
          if (mapTileMap.GetTile(new Vector3Int(x-1,1,0)) == tiles[3] && mapTileMap.GetTile(new Vector3Int(x+1,1,0)) == tiles[3]) {
            SetTile(x, 1, tiles[3]);
            SetTile(x, 0, tiles[3]);
          }
          if (mapTileMap.GetTile(new Vector3Int(x-1,1,0)) == tiles[2]) {
            SetTile(x, 1, tiles[3]);
            SetTile(x, 0, tiles[3]);
          }
        }
      }

      //underground XD
      for (int x=camX; x!=camX + generationRange; x++) {
        if (mapTileMap.GetTile(new Vector3Int(x,1,0)) == tiles[0]) {
          SetTile(x, 0, tiles[4]);
        } else if (mapTileMap.GetTile(new Vector3Int(x,1,0)) == tiles[1]) {
          SetTile(x, 0, tiles[5]);
        } else if (mapTileMap.GetTile(new Vector3Int(x,1,0)) == tiles[2]) {
          SetTile(x, 0, tiles[6]);
        }
      }

    }

    void SetTile(int x, int y, Tile tile){
      mapTileMap.SetTile(new Vector3Int(x,y,0), tile);
    }
}
