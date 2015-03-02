namespace RailDataEngine.Domain.Boundary.TrainDescriber.ProcessDescriberMessageBoundary
{
    public interface IProcessDescriberMessageBoundary
    {
        void Invoke(ProcessDescriberMessageBoundaryRequest request);
    }
}
