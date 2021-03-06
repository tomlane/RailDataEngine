﻿using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using RailDataEngine.Core;
using RailDataEngine.Domain.Services.MovementMessageDeserializationService;
using RailDataEngine.Services.MessageConversion.TrainMovements;

namespace RailDataEngine.UnitTests.Services.MessageConversion.TrainMovements
{
    [TestFixture]
    class TJsonMovementMessageDeserializationService
    {
        [Test]
        public void can_be_built_from_static_container()
        {
            var container = ContainerBuilder.Build();
            var service = container.Resolve<IMovementMessageDeserializationService>();
            Assert.IsInstanceOf<JsonMovementMessageDeserializationService>(service);
        }

        [TestFixture]
        class DeserializeMovementMessages
        {
            [Test]
            public void throws_when_argument_null()
            {
                var service = new JsonMovementMessageDeserializationService();

                Assert.Throws<ArgumentNullException>(() => service.DeserializeMovementMessages(null));
            }
        }
    }
}
