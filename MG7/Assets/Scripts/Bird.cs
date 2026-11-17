using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _popUpTime = 1.0f;
    [SerializeField] private float _popUpSpeed = 5.0f;
    [SerializeField] private Player _player;

    private bool _doPopUpAnimation;
    private float _popUpTimeRemaining;

    // Step 2: Start the timer when the bird becomes active.
    private void OnEnable()
    {
        _popUpTimeRemaining = _popUpTime;
        _doPopUpAnimation = _popUpTimeRemaining > 0f;
    }

    private void Update()
    {
        // Step 3: Move upward while the timer is running.
        if (_doPopUpAnimation)
        {
            float moveTime = Mathf.Min(Time.deltaTime, _popUpTimeRemaining);
            transform.Translate(Vector3.up * _popUpSpeed * moveTime, Space.World);

            _popUpTimeRemaining -= moveTime;
            _doPopUpAnimation = _popUpTimeRemaining > 0f;
        }

        // Step 6: Look at the player when the player is holding a seed.
    }
}