using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitTests.Helpers
{
    public class InMemoryLogger : Logger
    {
        private List<string> _loggerStatusEventRaised = new List<string>();
        public ReadOnlyCollection<string> LoggedStatusEventRaised => _loggerStatusEventRaised.AsReadOnly();
        public string ConcattedLoggedStatusEventRaised => string.Join(string.Empty, _loggerStatusEventRaised);

        public override void Initialize(IEventSource eventSource)
        {
            eventSource.StatusEventRaised += new BuildStatusEventHandler(eventSource_StatusEventRaised);
        }

        private void eventSource_StatusEventRaised(object sender, BuildStatusEventArgs e)
        {
            _loggerStatusEventRaised.Add(e.Message);
        }
    }
}
