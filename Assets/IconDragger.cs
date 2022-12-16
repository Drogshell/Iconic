using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IconDragger : MouseManipulator
{
    private Vector2 _startPosition;
    private Vector2 _startPositionGlobal;
    private Vector2 _startPositionLocal;
    
    
    private VisualElement _dragArea;
    private VisualElement _iconContainer;
    private VisualElement _dropZone;

    private bool _isActive;
    
    public IconDragger(VisualElement root)
    {
        _dragArea = root.Q("DragArea");
        _dropZone = root.Q("DropArea");

        _isActive = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
        target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
        target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
    }

    private void OnMouseDown(MouseDownEvent evt)
    {
        //Get The original container
        _iconContainer = target.parent;
        
        //Get the mouses start position
        _startPosition = evt.localMousePosition;
        
        //Get both target start positions
        _startPositionGlobal = target.worldBound.position;
        _startPositionLocal = target.layout.position;
        
        //Enable the drag area
        _dragArea.style.display = DisplayStyle.Flex;
        _dragArea.Add(target);

        target.style.top = _startPositionGlobal.y;
        target.style.left = _startPositionGlobal.x;
        
        _isActive = true;
        target.CaptureMouse();
        evt.StopPropagation();
    }
    
    private void OnMouseMove(MouseMoveEvent evt)
    {
        if (!_isActive || !target.HasMouseCapture()) return;
        
        
        Vector2 difference = evt.localMousePosition - _startPosition;

        target.style.top = target.layout.y + difference.y;
        target.style.left = target.layout.x + difference.x;
        
        evt.StopPropagation();
    }

    private void OnMouseUp(MouseUpEvent evt)
    {
        if (!_isActive || !target.HasMouseCapture()) return;

        _iconContainer.Add(target);
        
        /*
         * The code below sets the icon back in it's original container, we minus the contentRect
         * to get the EXACT position when first picked up.
         * This eliminates the bug where the icon constantly drifts from the old position
         */
        target.style.top = _startPositionLocal.y - _iconContainer.contentRect.position.y;
        target.style.left = _startPositionLocal.x - _iconContainer.contentRect.position.x;

        _isActive = false;
        target.ReleaseMouse();
        evt.StopPropagation();

        _dragArea.style.display = DisplayStyle.None;
    }
}
