using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class GasVolumeController : MonoBehaviour
{
    public bool isActive;
    bool GasActive = false;
    public GameObject smokeDetector;
    public AudioSource smokeSound;
    public Volume gasVolume;

    // Update is called once per frame
    void Start()
    {
        if (smokeDetector.activeInHierarchy)
        {
            Switch(isActive);
        }
    }

    public void Switch(bool isActive)
    {
        isActive = smokeDetector.activeSelf;
        gasVolume.weight = 0f;
        if (isActive != GasActive)
        {
            if (gasVolume != null)
            {
                GasActive = isActive;
                gasVolume.weight = 0f;
                smokeSound.mute = !isActive;
                DOTween.Sequence()
                    .Append(DOTween.To(() => gasVolume.weight, x => gasVolume.weight = x, 1f, 1f))
                    .OnComplete(() =>
                    {

                    });
            }
        }

    }
}
