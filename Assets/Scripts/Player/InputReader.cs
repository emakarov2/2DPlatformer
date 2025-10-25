using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    private bool _isInteracting;
    private bool _isDirectionDefault = true;

    public bool IsDirectionDefault => _isDirectionDefault;
    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Direction != 0)
        {
            _isDirectionDefault = Direction > 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _isInteracting = true;
        }
    }

    public bool GetIsInteracting() => GetBoolAsTrigger(ref _isInteracting);

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}