namespace RailDataEngine.Domain.Boundaries.TrainDescriber.ProcessDescriberMessageBoundary
{
    public interface IProcessDescriberMessageBoundary
    {
        void Invoke(ProcessDescriberMessageBoundaryRequest request);
    }
}
