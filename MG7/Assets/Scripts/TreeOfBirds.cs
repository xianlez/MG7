using UnityEngine;

public class TreeOfBirds : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] birds;
    [SerializeField] private float interactionDistance = 5f;

    private void Update()
    {
        if (player == null || birds == null)
        {
            return;
        }

        foreach (GameObject bird in birds)
        {
            if (bird == null || bird.activeSelf)
            {
                continue;
            }

            Vector3 toPlayer = player.position - bird.transform.position;
            if (toPlayer.magnitude <= interactionDistance)
            {
                bird.SetActive(true);
            }
        }
    }
}