using System;
using System.Linq;
using System.Threading.Tasks;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Interactor.SaveMovementMessageInteractor;
using RailDataEngine.Domain.Services.MovementMessageConversionService;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Domain.Services.MovementMessageStorageService;
using RailDataEngine.Domain.Services.TwitterService;

namespace RailDataEngine.Core.Interactor.TrainMovements
{
    public class SaveMovementMessageInteractor : ISaveMovementMessageInteractor
    {
        private readonly IMovementMessageDeserializationService _messageDeserializationService;
        private readonly IMovementMessageConversionService _messageConversionService;
        private readonly IMovementMessageStorageService _messageStorageService;
        private readonly ITwitterService _twitterService;

        public SaveMovementMessageInteractor(IMovementMessageDeserializationService movementMessageDeserializationService, IMovementMessageConversionService movementMessageConversionService, IMovementMessageStorageService movementMessageStorageService, ITwitterService twitterService)
        {
            if (movementMessageDeserializationService == null)
                throw new ArgumentNullException("movementMessageDeserializationService");
            if (movementMessageConversionService == null)
                throw new ArgumentNullException("movementMessageConversionService");
            if (movementMessageStorageService == null) 
                throw new ArgumentNullException("movementMessageStorageService");
            if (twitterService == null)
                throw new ArgumentNullException("twitterService");

            _messageDeserializationService = movementMessageDeserializationService;
            _messageConversionService = movementMessageConversionService;
            _messageStorageService = movementMessageStorageService;
            _twitterService = twitterService;
        }

        public void SaveMovementMessages(SaveMovementMessageInteractorRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.MessageToSave))
                throw new ArgumentNullException("request");

            var deserializedMessages =
                _messageDeserializationService.DeserializeMovementMessages(new MovementMessageDeserializationRequest
                {
                    MessageToDeserialize = request.MessageToSave
                });

            var convertedMessages =
                _messageConversionService.ConvertMovementMessages(new MovementMessageConversionRequest
                {
                    Activations = deserializedMessages.Activations,
                    Cancellations = deserializedMessages.Cancellations,
                    Movements = deserializedMessages.Movements
                });

            var tasks = new[]
            {
                Task.Factory.StartNew(() => SaveMessages(convertedMessages)),
                Task.Factory.StartNew(() => ProcessLateTweets(convertedMessages))
            };

            Task.WaitAll(tasks);
        }

        private void ProcessLateTweets(MovementMessageConversionResponse convertedMessages)
        {
            var lateTrains =
                convertedMessages.Movements.Where(
                    x => x.VariationStatus == VariationStatus.Late && x.TimetableVariation >= 10 && x.PassengerTimestamp != null).ToList();

            if (!lateTrains.Any())
                return;

            var lateTweetsToSend = lateTrains.Select(trainMovement => new LateServiceTweetInfo
            {
                Delay = trainMovement.TimetableVariation ?? 0,
                PassengerTimestamp = trainMovement.PassengerTimestamp ?? DateTime.UtcNow,
                Stanox = trainMovement.LocationStanox,
                TrainId = trainMovement.TrainId,
                IsCorrection = trainMovement.IsCorrection ?? false
            }).ToList();

            _twitterService.SendLateTweets(new LateTrainTweetRequest
            {
                LateServiceList = lateTweetsToSend
            });
        }

        private void SaveMessages(MovementMessageConversionResponse convertedMessages)
        {
            _messageStorageService.SaveMovementMessages(new SaveMovementMessagesRequest
            {
                Activations = convertedMessages.Activations,
                Cancellations = convertedMessages.Cancellations,
                Movements = convertedMessages.Movements
            });
        }
    }
}
