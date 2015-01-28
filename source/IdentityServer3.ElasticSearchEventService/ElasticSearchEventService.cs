﻿using Serilog.Sinks.ElasticSearch;
using Thinktecture.IdentityServer.Core.Events;
using Thinktecture.IdentityServer.Core.Services;

namespace Thinktecture.IdentityServer.Services.Contrib
{
    public class ElasticSearchEventService : IEventService
    {
        private readonly Emitter _emitter;

        public ElasticSearchEventService(ElasticsearchSinkOptions options, IAddExtraPropertiesToEvents adder = null)
        {
            var sink = new ElasticsearchSink(options);
            _emitter = new Emitter(sink, adder);
        }

        public void Raise<T>(Event<T> evt)
        {
            _emitter.Emit(evt);
        }
    }
}
