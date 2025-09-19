using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Item
{
    [SerializeField] private float _lifeTimeSeconds = 20f;

    private List<GameObject> _allChildObjects = new List<GameObject>();
    private Collider[] _colliders;

    private Rigidbody _rigidbody;
    private Coroutine _timerCoroutine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Add all transform childs
        foreach (Transform child in gameObject.transform)
        {
            _allChildObjects.Add(child.gameObject);
        }

        _colliders = GetComponents<Collider>();

    }
    private void OnEnable()
    {
        InInventory = false;
        OnAddedInInventory += PickUpApple;

        ToggleAllColliders(true);
        ToggleAllChildren(true);

        if (_timerCoroutine == null)
            _timerCoroutine = StartCoroutine(AppleLifeTimer());
    }

    private void OnDisable()
    {
        OnAddedInInventory -= PickUpApple;

        StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
        DisableApplePhysics();
    }

    public void PickUpApple()
    {
        ToggleAllColliders(false);
        ToggleAllChildren(false);

        InInventory = true;
    }

    #region Toggle Timer
    public void StartLifetimeTimer()
    {
        if (_timerCoroutine != null) return;

        _timerCoroutine = StartCoroutine(AppleLifeTimer());
    }

    #endregion

    #region Toggle Physics

    public void EnableApplePhysics()
    {
        _rigidbody.isKinematic = false;
    }

    public void DisableApplePhysics()
    {
        _rigidbody.isKinematic = true;
    }

    #endregion

    #region Utils

    // Temporary method to toggle all child objects on/off.
    // Used as a placeholder because there is no actual apple model yet.
    private void ToggleAllChildren(bool enable)
    {
        foreach (GameObject child in _allChildObjects)
        {
            child.SetActive(enable);
        }
    }

    private void ToggleAllColliders(bool enable)
    {
        foreach (Collider collider in _colliders)
        {
            collider.enabled = enable;
        }
    }

    #endregion

    private IEnumerator AppleLifeTimer()
    {
        yield return new WaitForSeconds(_lifeTimeSeconds);

        EventHandler.InvokeOnAppleSpoiled(this);
        gameObject.SetActive(false);
        _timerCoroutine = null;
    }
}