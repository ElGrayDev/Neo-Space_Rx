using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAsteroidsGenerator : MonoBehaviour {

    [SerializeField] private GameObject[] AsteroidsType;

    [SerializeField] private int IntAsteroids;

    [SerializeField] private Vector2 MinPoint,MaxPoint;

    [SerializeField] private Transform PlayerTrans;
	
	void Start () {
		
        for (var i = 0; i < IntAsteroids; i++)
        {
            var asteroidCreate = AsteroidsType[Random.Range(0, AsteroidsType.Length)];

           float PosX = Random.Range(MinPoint.x, MaxPoint.x);
           float PosY = Random.Range(MinPoint.y, MaxPoint.y);
           float PosZ = 0;


           Vector3 Pos = new Vector3(PosX,PosY,PosZ);

        
          GameObject Asteroids = Instantiate(asteroidCreate, Pos, Quaternion.identity);
            Asteroids.transform.parent = transform;

            float distance = Vector2.Distance(Asteroids.transform.position, PlayerTrans.position);

            if (distance < 78)
            {
                Destroy(asteroidCreate.gameObject);
                i--;
            }
            
        }

	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(new Vector3(MinPoint.x, MaxPoint.y, 0f), new Vector3(MaxPoint.x, MaxPoint.y, 0f));
        Gizmos.DrawLine(new Vector3(MinPoint.x, MinPoint.y, 0f), new Vector3(MaxPoint.x, MinPoint.y, 0f));
        Gizmos.DrawLine(new Vector3(MinPoint.x, MaxPoint.y, 0f), new Vector3(MinPoint.x, MinPoint.y, 0f));
        Gizmos.DrawLine(new Vector3(MaxPoint.x, MaxPoint.y, 0f), new Vector3(MaxPoint.x, MinPoint.y, 0f));
    }

}
