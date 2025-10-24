using UnityEngine;

interface IMover
{
    bool IsDirectionDefault {get;}

    void Move(Vector2 target);
    void Stop();
    void Continue();    
}
