using Dreamteck.Splines;

namespace submodules.CommonScripts.CommonScripts.Utilities.Extensions
{
    public static class SplineExtensions
    {
        public static void InvertDirection(this SplineTracer tracer) =>
            tracer.direction = tracer.direction == Spline.Direction.Forward ? Spline.Direction.Backward : Spline.Direction.Forward;
    }
}