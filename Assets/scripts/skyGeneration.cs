using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Tilemap))]
public class skyGeneration : MonoBehaviour
{
  [SerializeField]Tile[] tiles;
  [SerializeField][Range(100, 5)]int chance;
  [SerializeField]Transform player;
  Tilemap skyTileMap;

    void Awake(){
      skyTileMap = GetComponent<Tilemap>();

      //error message
      if (!skyTileMap)
        Debug.LogError("can't get tilemap");
    }

    void Update(){
      int playerX = Mathf.RoundToInt(Mathf.Floor(player.position.x));
      Generate(playerX);
    }

    public void Generate(int playerX){
      for (int y=0; y<=10; y++) {
        skyTileMap.SetTile(new Vector3Int(playerX-1,y,0), null);
        skyTileMap.SetTile(new Vector3Int(playerX-2,y,0), null);
        skyTileMap.SetTile(new Vector3Int(playerX-3,y,0), null);
      }

      for (int x=playerX; x!=playerX+30; x++) {
        for (int y=0; y<=9; y++) {
          if (skyTileMap.GetTile(new Vector3Int(x,y,0))) {
            continue;
          }
          if (y==9) {
            SetTile(x,y, tiles[1]);
          } else if (y==8){
            SetTile(x,y, tiles[0]);
          } else {
            switch(Random.Range(0, chance))
            {
              case 1:
               SetTile(x,y, tiles[3]);
               break;
              case 2:
                SetTile(x,y, tiles[4]);
                break;
              case 3:
                SetTile(x,y, tiles[5]);
                break;
              case 4:
                SetTile(x,y, tiles[6]);
                break;
              default:
                SetTile(x,y, tiles[2]);
                break;
            }
          }
        }
      }
    }

    void SetTile(int x, int y, Tile tile){
      skyTileMap.SetTile(new Vector3Int(x,y,0), tile);
    }
}
