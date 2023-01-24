using System.Collections;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private GameObject[] _nests;
    [SerializeField][Range(1, 10)] private float _spawnInterval = 2;
    [SerializeField] private Vector3 _spawnOffset;

    private void Start()
    {
        StartCoroutine(SpawnEgg());
    }

    private IEnumerator SpawnEgg()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, _nests.Length);
            Vector3 spawnPosition = _nests[randomIndex].transform.position;

            if (_nests[randomIndex].transform.localScale.x < 0)
                spawnPosition += new Vector3(_spawnOffset.x, _spawnOffset.y, 0);
            else
                spawnPosition -= new Vector3(_spawnOffset.x, _spawnOffset.y, 0);

            Instantiate(_eggPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
