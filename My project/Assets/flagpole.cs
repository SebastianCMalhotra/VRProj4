using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag = "PlayerTag";
    [SerializeField] private string sceneName = "finish";

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"hit: {other.name}, tag on it: {other.tag}");
        
        Transform t = other.transform;
        while (t != null)
        {
            if (t.CompareTag(playerTag))
            {
                SceneManager.LoadScene(sceneName);
                return;
            }
            t = t.parent;
        }
    }
}