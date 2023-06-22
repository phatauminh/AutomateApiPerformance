using System;

namespace Hub.Core.Plugins
{
    public interface IPluginProvider
    {
        event EventHandler<PluginEventArgs> PreTestInitEvent;

        event EventHandler<PluginEventArgs> TestInitFailedEvent;

        event EventHandler<PluginEventArgs> PostTestInitEvent;

        event EventHandler<PluginEventArgs> PreTestCleanupEvent;

        event EventHandler<PluginEventArgs> PostTestCleanupEvent;

        event EventHandler<PluginEventArgs> TestCleanupFailedEvent;

        event EventHandler<PluginEventArgs> PreTestsActEvent;

        event EventHandler<PluginEventArgs> PreTestsArrangeEvent;

        event EventHandler<PluginEventArgs> PostTestsActEvent;

        event EventHandler<PluginEventArgs> PostTestsArrangeEvent;

        event EventHandler<PluginEventArgs> PreTestsCleanupEvent;

        event EventHandler<PluginEventArgs> PostTestsCleanupEvent;

        event EventHandler<Exception> TestsCleanupFailedEvent;

        event EventHandler<Exception> TestsArrangeFailedEvent;
    }
}
