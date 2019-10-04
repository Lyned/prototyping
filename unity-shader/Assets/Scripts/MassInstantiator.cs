using System.Collections;
using UnityEngine;

public class MassInstantiator : MonoBehaviour
{
    public GameObject VegetationPrefab;
    public int Amount = 10;
    public float Radius = 4;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            Vector2 uc = Random.insideUnitCircle;

            Vector3 position = (new Vector3(uc.x, 0, uc.y)) * Radius;
            Vector3 scale = Vector3.one + Vector3.up * Random.Range(0, 1);

            var obj = Instantiate(VegetationPrefab, position, Quaternion.identity, this.transform);
            obj.transform.localScale = scale;
        }
    }
}