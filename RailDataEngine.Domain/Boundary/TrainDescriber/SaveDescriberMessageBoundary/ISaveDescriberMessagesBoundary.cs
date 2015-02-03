namespace RailDataEngine.Domain.Boundary.TrainDescriber.SaveDescriberMessageBoundary
{
    public interface ISaveDescriberMessagesBoundary
    {
        void Invoke(SaveDescriberBoundaryRequest request);
    }
}
