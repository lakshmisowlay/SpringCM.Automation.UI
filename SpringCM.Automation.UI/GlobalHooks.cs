using SpringCM.Automation.Core;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpringCM.Automation.UI
{
    [Binding]
    public class GlobalHooks
    {
        [AfterScenario()]
        public static void CloseApplication(ScenarioContext context)
        {
            var application = context.Application();
            application.Exit();
            context.DetachApplication();
        }

        [AfterTestRun()]
        public static void KillDrivers()
        {
            //TODO: do the same for other drivers
            try
            {
                var orphanProcesses = Process.GetProcessesByName("chromedrivers.exe");
                foreach (var process in orphanProcesses)
                {
                    process.Kill();
                }
            }
            catch (Exception)
            {
                //TODO
            }

        }
    }
}
