using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public static class ScreenTools
{
    public static bool IsPointerOverUIObject()
    {
        var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Any(result => result.gameObject.layer == 5);
    }

    /*public static bool IsPointerOverUIObjectIgnoreJoystick()
    {
        var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return !results.Where(result => result.gameObject.layer == 5)
            .Any(res => res.gameObject.TryGetComponent(out Joystick _));
    }*/

    public static ScreenValues GetScreenValues()
    {
        Camera camera = Camera.main;
        if (camera is null) throw new Exception("Camera isn't find");

        float height = camera.orthographicSize * 2.0f;
        float width = height * camera.aspect;

        return ScreenValues.CreateInstance(width, height);
    }

    public struct ScreenValues
    {
        private ScreenValues(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }

        public float Height { get; }

        public static ScreenValues CreateInstance(float width, float height) =>
            new ScreenValues(width, height);

        public float HalfHeight => Height * 0.5f;
        public float HalfWidth => Width * 0.5f;
    }
}