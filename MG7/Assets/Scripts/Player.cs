using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _spawnUp = 0.5f;
    [SerializeField] private float _spawnLeft = 0.2f;
    [SerializeField] private GameObject _seedPrefab;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _throwForce = 5.0f;

    public bool _isHoldingSeed;

    private Transform _cameraTrans;
    private float _rotationX;
    private float _rotationY;
    private Rigidbody _seedRB;
    private Collider _seedCollider;

    private void Start()
    {
        _cameraTrans = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LookAndMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isHoldingSeed)
            {
                ThrowSeed();
            }
            else
            {
                SpawnSeed();
            }
        }
    }

    private void SpawnSeed()
    {
        _isHoldingSeed = true;

        // Step 4: Parent the seed to the player.
        GameObject seed = Instantiate(_seedPrefab, transform);

        _seedRB = seed.GetComponent<Rigidbody>();
        _seedRB.isKinematic = true;
        _seedCollider = seed.GetComponent<Collider>();
        _seedCollider.enabled = false;

        // Step 5: Place the seed to the player's left and slightly above.
        Vector3 localOffset = Vector3.left * _spawnLeft + Vector3.up * _spawnUp;
        seed.transform.position = transform.position
            + transform.TransformDirection(localOffset);
    }

    private void ThrowSeed()
    {
        _isHoldingSeed = false;
        _seedRB.transform.SetParent(null, true);
        _seedRB.isKinematic = false;
        _seedCollider.enabled = true;

        Vector3 throwDirection =
            transform.TransformDirection(Vector3.up + Vector3.forward);
        _seedRB.AddForce(throwDirection * _throwForce, ForceMode.Impulse);

        _seedRB = null;
        _seedCollider = null;

        // Step 7: Trigger the throwing animation.
        _animator.SetTrigger("Throw");
    }

    private void LookAndMove()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        _rotationY += mouseY * _mouseSensitivity;
        _rotationY = Mathf.Clamp(_rotationY, -60.0f, 60.0f);

        float mouseX = Input.GetAxis("Mouse X");
        _rotationX += mouseX * _mouseSensitivity;

        _cameraTrans.localEulerAngles = new Vector3(-_rotationY, 0, 0);
        transform.localEulerAngles = new Vector3(0, _rotationX, 0);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = vertical * Vector3.forward + horizontal * Vector3.right;
        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        // Step 8: Play the walking animation while moving.
        bool isWalking = movement.sqrMagnitude > 0.0001f;
        _animator.SetBool("IsWalking", isWalking);
    }
}