using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.API.Assertions
{
    public abstract class AssertExtensionsEventHandlers
    {
        public virtual void SubscribeToAll()
        {
            AssertExtensions.AssertExecutionTimeUnderEvent += AssertExecutionTimeUnderEventHandler;
            AssertExtensions.AssertContentContainsEvent += AssertContentContainsEventHandler;
            AssertExtensions.AssertContentNotContainsEvent += AssertContentNotContainsEventHandler;
            AssertExtensions.AssertContentEqualsEvent += AssertContentEqualsEventHandler;
            AssertExtensions.AssertContentNotEqualsEvent += AssertContentNotEqualsEventHandler;
            AssertExtensions.AssertResultEqualsEvent += AssertResultEqualsEventHandler;
            AssertExtensions.AssertResultNotEqualsEvent += AssertResultNotEqualsEventHandler;
            AssertExtensions.AssertSuccessStatusCodeEvent += AssertSuccessStatusCodeEventHandler;
            AssertExtensions.AssertStatusCodeEvent += AssertStatusCodeEventHandler;
            AssertExtensions.AssertResponseHeaderEvent += AssertResponseHeaderEventHandler;
            AssertExtensions.AssertContentTypeEvent += AssertContentTypeEventHandler;
            AssertExtensions.AssertContentEncodingEvent += AssertContentEncodingEventHandler;
            AssertExtensions.AssertCookieExistsEvent += AssertCookieExistsEventHandler;
            AssertExtensions.AssertCookieEvent += AssertCookieEventHandler;
            AssertExtensions.AssertSchemaEvent += AssertSchemaEventHandler;
        }

        public virtual void UnsubscribeToAll()
        {
            AssertExtensions.AssertExecutionTimeUnderEvent -= AssertExecutionTimeUnderEventHandler;
            AssertExtensions.AssertContentContainsEvent -= AssertContentContainsEventHandler;
            AssertExtensions.AssertContentNotContainsEvent -= AssertContentNotContainsEventHandler;
            AssertExtensions.AssertContentEqualsEvent -= AssertContentEqualsEventHandler;
            AssertExtensions.AssertContentNotEqualsEvent -= AssertContentNotEqualsEventHandler;
            AssertExtensions.AssertResultEqualsEvent -= AssertResultEqualsEventHandler;
            AssertExtensions.AssertResultNotEqualsEvent -= AssertResultNotEqualsEventHandler;
            AssertExtensions.AssertSuccessStatusCodeEvent -= AssertSuccessStatusCodeEventHandler;
            AssertExtensions.AssertStatusCodeEvent -= AssertStatusCodeEventHandler;
            AssertExtensions.AssertResponseHeaderEvent -= AssertResponseHeaderEventHandler;
            AssertExtensions.AssertContentTypeEvent -= AssertContentTypeEventHandler;
            AssertExtensions.AssertContentEncodingEvent -= AssertContentEncodingEventHandler;
            AssertExtensions.AssertCookieExistsEvent -= AssertCookieExistsEventHandler;
            AssertExtensions.AssertCookieEvent -= AssertCookieEventHandler;
            AssertExtensions.AssertSchemaEvent -= AssertSchemaEventHandler;
        }

        protected virtual void AssertExecutionTimeUnderEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentContainsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentNotContainsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentEqualsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentNotEqualsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertResultEqualsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertResultNotEqualsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertSuccessStatusCodeEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertStatusCodeEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertResponseHeaderEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentTypeEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertContentEncodingEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertCookieExistsEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertCookieEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }

        protected virtual void AssertSchemaEventHandler(object sender, ApiAssertEventArgs arg)
        {
        }
    }
}
