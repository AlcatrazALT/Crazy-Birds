using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }

        Debug.Log("All enemies killed");

        _nextLevelIndex++;
        var nextLevelName = "Level" + _nextLevelIndex;

        SceneManager.LoadScene(nextLevelName);
    }

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
}