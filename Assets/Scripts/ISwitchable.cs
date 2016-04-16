using UnityEngine;

public interface ISwitchable {

    void Activate();
    void DeActivate();
    void Switch();
    bool GetState();
}
