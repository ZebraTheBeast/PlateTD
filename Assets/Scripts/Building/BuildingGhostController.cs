using UnityEngine;

public class BuildingGhostController
{
    public bool IsActive { get; private set; }

    private Material _ghostMaterialSuccess;
    private Material _ghostMaterialFail;
    private GameObject _ghostObject;
    private Renderer _ghostRenderer;

    public BuildingGhostController(Material ghostMaterialSuccess, Material ghostMaterialFail)
    {
        _ghostMaterialSuccess = ghostMaterialSuccess;
        _ghostMaterialFail = ghostMaterialFail;
    }

    public void CreateGhost(GameObject gameObject, Vector3 position)
    {
        if (_ghostObject != null)
        {
            DestroyGhost();
        }

        _ghostObject = GameObject.Instantiate(gameObject, position, Quaternion.identity);
        _ghostRenderer = _ghostObject.GetComponent<Renderer>();
        _ghostRenderer.material = _ghostMaterialFail;
        IsActive = true;
    }

    public void Update(Vector3 position, bool ghostCanBePlaces)
    {
        _ghostRenderer.material = ghostCanBePlaces ? _ghostMaterialSuccess : _ghostMaterialFail;
        _ghostObject.transform.position = position;
    }

    public void DestroyGhost()
    {
        GameObject.Destroy(_ghostObject);
        IsActive = false;
    }

}