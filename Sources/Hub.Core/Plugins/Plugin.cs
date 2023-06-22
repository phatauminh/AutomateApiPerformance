using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hub.Core.Plugins
{
    public class Plugin
    {
        public void Subscribe(IPluginProvider provider)
        {
            provider.PreTestInitEvent += PreTestInit;
            provider.TestInitFailedEvent += TestInitFailed;
            provider.PostTestInitEvent += PostTestInit;
            provider.PreTestCleanupEvent += PreTestCleanup;
            provider.PostTestCleanupEvent += PostTestCleanup;
            provider.TestCleanupFailedEvent += TestCleanupFailed;
            provider.PreTestsArrangeEvent += PreTestsArrange;
            provider.TestsArrangeFailedEvent += TestsArrangeFailed;
            provider.PreTestsActEvent += PreTestsAct;
            provider.PostTestsActEvent += PostTestsAct;
            provider.PostTestsArrangeEvent += PostTestsArrange;
            provider.PreTestsCleanupEvent += PreTestsCleanup;
            provider.PostTestsCleanupEvent += PostTestsCleanup;
            provider.TestsCleanupFailedEvent += TestsCleanupFailed;
        }

        public void Unsubscribe(IPluginProvider provider)
        {
            provider.PreTestInitEvent -= PreTestInit;
            provider.TestInitFailedEvent -= TestInitFailed;
            provider.PostTestInitEvent -= PostTestInit;
            provider.PreTestCleanupEvent -= PreTestCleanup;
            provider.PostTestCleanupEvent -= PostTestCleanup;
            provider.TestCleanupFailedEvent -= TestCleanupFailed;
            provider.PreTestsArrangeEvent -= PreTestsArrange;
            provider.TestsArrangeFailedEvent -= TestsArrangeFailed;
            provider.PreTestsActEvent -= PreTestsAct;
            provider.PostTestsActEvent -= PostTestsAct;
            provider.PostTestsArrangeEvent -= PostTestsArrange;
            provider.PreTestsCleanupEvent -= PreTestsCleanup;
            provider.PostTestsCleanupEvent -= PostTestsCleanup;
            provider.TestsCleanupFailedEvent -= TestsCleanupFailed;
        }

        protected virtual void TestsCleanupFailed(object sender, Exception ex)
        {
        }

        protected virtual void PreTestsCleanup(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PostTestsCleanup(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PreTestInit(object sender, PluginEventArgs e)
        {
        }

        protected virtual void TestInitFailed(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PostTestInit(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PreTestCleanup(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PostTestCleanup(object sender, PluginEventArgs e)
        {
        }

        protected virtual void TestCleanupFailed(object sender, PluginEventArgs e)
        {
        }

        protected virtual void TestsArrangeFailed(object sender, Exception e)
        {
        }

        protected virtual void PreTestsAct(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PreTestsArrange(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PostTestsAct(object sender, PluginEventArgs e)
        {
        }

        protected virtual void PostTestsArrange(object sender, PluginEventArgs e)
        {
        }

        protected List<dynamic> GetAllAttributes<TAttribute>(MemberInfo memberInfo)
        where TAttribute : Attribute
        {
            var classAttributes = GetClassAttributes<TAttribute>(memberInfo.DeclaringType);
            var methodAttributes = GetMethodAttributes<TAttribute>(memberInfo);
            var attributes = classAttributes.ToList();
            attributes.AddRange(methodAttributes);

            return attributes;
        }

        protected TAttribute GetOverridenAttribute<TAttribute>(MemberInfo memberInfo)
        where TAttribute : Attribute
        {
            var classAttribute = GetClassAttribute<TAttribute>(memberInfo.DeclaringType);
            var methodAttribute = GetMethodAttribute<TAttribute>(memberInfo);
            if (methodAttribute != null)
            {
                return methodAttribute;
            }

            return classAttribute;
        }

        protected dynamic GetClassAttribute<TAttribute>(Type currentType)
        where TAttribute : Attribute
        {
            var classAttribute = currentType.GetCustomAttribute<TAttribute>(true);

            return classAttribute;
        }

        protected dynamic GetMethodAttribute<TAttribute>(MemberInfo memberInfo)
        where TAttribute : Attribute
        {
            var methodAttribute = memberInfo?.GetCustomAttribute<TAttribute>(true);

            return methodAttribute;
        }

        protected IEnumerable<dynamic> GetClassAttributes<TAttribute>(Type currentType)
        where TAttribute : Attribute
        {
            var classAttributes = currentType.GetCustomAttributes<TAttribute>(true);

            return classAttributes;
        }

        protected IEnumerable<dynamic> GetMethodAttributes<TAttribute>(MemberInfo memberInfo)
        where TAttribute : Attribute
        {
            var methodAttributes = memberInfo?.GetCustomAttributes<TAttribute>(true);

            return methodAttributes;
        }
    }
}
