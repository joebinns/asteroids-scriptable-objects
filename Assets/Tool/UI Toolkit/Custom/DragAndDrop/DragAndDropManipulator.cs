using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDropManipulator : PointerManipulator
{
    public DragAndDropManipulator(VisualElement target)
    {
        this.target = target;
        root = target.parent.parent.parent;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerDownEvent>(PointerDownHandler);
        target.RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
        target.RegisterCallback<PointerUpEvent>(PointerUpHandler);
        target.RegisterCallback<PointerCaptureOutEvent>(PointerCaptureOutHandler);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerDownEvent>(PointerDownHandler);
        target.UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
        target.UnregisterCallback<PointerUpEvent>(PointerUpHandler);
        target.UnregisterCallback<PointerCaptureOutEvent>(PointerCaptureOutHandler);
    }

    private Vector2 targetStartPosition { get; set; }

    private Vector3 pointerStartPosition { get; set; }

    private bool enabled { get; set; }

    private VisualElement root { get; }

    private void PointerDownHandler(PointerDownEvent evt)
    {
        targetStartPosition = target.transform.position;
        pointerStartPosition = evt.position;
        target.CapturePointer(evt.pointerId);
        enabled = true;
    }

    private void PointerMoveHandler(PointerMoveEvent evt)
    {
        if (enabled && target.HasPointerCapture(evt.pointerId))
        {
            Vector3 pointerDelta = evt.position - pointerStartPosition;
            
            target.transform.position = new Vector2(targetStartPosition.x + pointerDelta.x,
                targetStartPosition.y + pointerDelta.y);
            /*
            target.transform.position = new Vector2(
                Mathf.Clamp(targetStartPosition.x + pointerDelta.x, 0, target.panel.visualTree.worldBound.width),
                Mathf.Clamp(targetStartPosition.y + pointerDelta.y, 0, target.panel.visualTree.worldBound.height));
            */
        }
    }

    private void PointerUpHandler(PointerUpEvent evt)
    {
        if (enabled && target.HasPointerCapture(evt.pointerId))
        {
            target.ReleasePointer(evt.pointerId);

            // Add the available class to neighbouring grid spaces
            var closestOverlappingSlot = FindClosestSlot();
            if (root.Query(className: "available").ToList().Contains(closestOverlappingSlot))
            {
                var directions = new List<Vector2Int>
                {
                    Vector2Int.up,
                    Vector2Int.right,
                    Vector2Int.down,
                    Vector2Int.left
                };
                var unitGridCoordinate = FindUnitGridCoordinates(new List<VisualElement> { closestOverlappingSlot })[0];
                var neighbourUnitGridCoordinates = directions.Select(direction => unitGridCoordinate + direction).ToList();
                var neighbourVisualElements = FindVisualElements(neighbourUnitGridCoordinates);
                foreach (var neighbour in neighbourVisualElements)
                {
                    neighbour.AddToClassList("available");
                }
                
                //closestOverlappingSlot.RemoveFromClassList("available");
                closestOverlappingSlot.AddToClassList("hull");
            }
        }
    }
    
    private List<Vector2Int> FindUnitGridCoordinates(List<VisualElement> slots)
    {
        var unitGridCoordinates = new List<Vector2Int>();
        // Identify grid coordinates of elements
        const int WIDTH = 5;
        var x = 0;
        var y = 0;
        foreach (var visualElement in root.Query(className: "slot").ToList()) {
            // Check if the current element is at a grid coordinate of interest
            var unitGridCoordinate = new Vector2Int(x, y);
            if (slots.Contains(visualElement))
            {
                unitGridCoordinates.Add(unitGridCoordinate);
            }
            // Sweep by rows then columns
            if (x == WIDTH - 1) y++;
            x++;
            x %= WIDTH;
        }
        return unitGridCoordinates;
    }
    
    private List<VisualElement> FindVisualElements(List<Vector2Int> unitGridCoordinates)
    {
        var visualElements = new List<VisualElement>();
        // Identify grid coordinates of elements
        const int WIDTH = 5;
        var x = 0;
        var y = 0;
        foreach (var visualElement in root.Query(className: "slot").ToList()) {
            // Check if the current element is at a grid coordinate of interest
            var unitGridCoordinate = new Vector2Int(x, y);
            if (unitGridCoordinates.Contains(unitGridCoordinate))
            {
                visualElements.Add(visualElement);
            }
            // Sweep by rows then columns
            if (x == WIDTH - 1) y++;
            x++;
            x %= WIDTH;
        }
        return visualElements;
    }

    private void PointerCaptureOutHandler(PointerCaptureOutEvent evt)
    {
        if (enabled)
        {
            /*
            var closestOverlappingSlot = FindClosestSlot();
            Vector3 closestPos = Vector3.zero;
            if (closestOverlappingSlot != null)
            {
                closestPos = RootSpaceOfSlot(closestOverlappingSlot);
                closestPos = new Vector2(closestPos.x - 5, closestPos.y - 5);
            }
            target.transform.position =
                closestOverlappingSlot != null ?
                closestPos :
                targetStartPosition;
                */
            target.transform.position = targetStartPosition;

            enabled = false;
        }
    }

    private VisualElement FindClosestSlot()
    {
        VisualElement slotsContainer = root.Q<VisualElement>("slots");
        UQueryBuilder<VisualElement> allSlots = slotsContainer.Query<VisualElement>(className: "slot");
        UQueryBuilder<VisualElement> overlappingSlots = allSlots.Where(OverlapsTarget);
        VisualElement closestOverlappingSlot = FindClosestSlot(overlappingSlots);
        return closestOverlappingSlot;
    }
    
    private bool OverlapsTarget(VisualElement slot)
    {
        return target.worldBound.Overlaps(slot.worldBound);
    }

    private VisualElement FindClosestSlot(UQueryBuilder<VisualElement> slots)
    {
        List<VisualElement> slotsList = slots.ToList();
        float bestDistanceSq = float.MaxValue;
        VisualElement closest = null;
        foreach (VisualElement slot in slotsList)
        {
            Vector3 displacement =
                RootSpaceOfSlot(slot) - target.transform.position;
            float distanceSq = displacement.sqrMagnitude;
            if (distanceSq < bestDistanceSq)
            {
                bestDistanceSq = distanceSq;
                closest = slot;
            }
        }
        return closest;
    }

    private Vector3 RootSpaceOfSlot(VisualElement slot)
    {
        Vector2 slotWorldSpace = slot.parent.LocalToWorld(slot.layout.position);
        return root.WorldToLocal(slotWorldSpace);
    }
}
