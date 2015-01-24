namespace RailDataEngine.Boundary.SaveMovementMessageBoundary
{
    public interface ISaveMovementMessagesBoundary
    {
        void Invoke(SaveMovementsBoundaryRequest request);
    }
}
