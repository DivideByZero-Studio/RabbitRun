using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpsView : MonoBehaviour
{
    [SerializeField] private List<JumpIndicator> jumpIndicators;

    private int _currentJumpIndex;
    private int _jumpsAmount;
    private float _reloadProgress;
    private bool _isReloading;
    
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _jumpsAmount = jumpIndicators.Count;
        _currentJumpIndex= _jumpsAmount - 1;

        foreach (var indicator in jumpIndicators)
        {
            indicator.Fill();
        }
    }

    public void StartReloadView(float reloadTime, bool decreaseJumpIndex = true)
    {
        _currentJumpIndex -= decreaseJumpIndex ? 1 : 0;
        
        if (_isReloading)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = StartCoroutine(ReloadFromProgressCoroutine(reloadTime));
        }
        else
        {
            _currentCoroutine = StartCoroutine(ReloadCoroutine(reloadTime));
        }
    }
    
    private IEnumerator ReloadCoroutine(float reloadTime)
    {
        _isReloading = true;
        
        var jumpIndicator = jumpIndicators[_currentJumpIndex+1];
        var progressStep = 1 / reloadTime;
        //Debug.Log($"STEP: {progressStep}");
        
        while (reloadTime > 0)
        {
            _reloadProgress += progressStep * Time.deltaTime;
            //Debug.Log($"PROGRESS: {_reloadProgress}");
            jumpIndicator.SetReloadProgress(_reloadProgress);
            
            reloadTime -= Time.deltaTime;
            
            yield return null;
        }
        _currentJumpIndex++;
        
        _reloadProgress = 0;
        jumpIndicator.Fill();
        
        _isReloading = false;
    }
    
    private IEnumerator ReloadFromProgressCoroutine(float reloadTime)
    {
        _isReloading = true;
        
        var previousJump = jumpIndicators[_currentJumpIndex + 2];
        previousJump.Clear();
        
        var jumpIndicator = jumpIndicators[_currentJumpIndex+1];
        var progressStep = 1 / reloadTime;
        var reloadTimeLeft = reloadTime * (1 - _reloadProgress);
        
        _currentJumpIndex--;
        while (reloadTimeLeft > 0)
        {
            _reloadProgress += progressStep;
            jumpIndicator.SetReloadProgress(_reloadProgress);
            
            reloadTimeLeft -= Time.deltaTime;
            
            yield return null;
        }
        _currentJumpIndex++;
        
        _reloadProgress = 0;
        jumpIndicator.Fill();
        
        _isReloading = false;
        
        StartReloadView(reloadTime, decreaseJumpIndex: false);
    }
}
