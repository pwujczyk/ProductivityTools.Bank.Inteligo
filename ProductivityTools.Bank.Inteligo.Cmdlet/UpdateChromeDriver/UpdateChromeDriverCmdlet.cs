using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.UpdateChromeDriver
{
    [Cmdlet("Update", "InteligoChromeDriver")]
    public class UpdateChromeDriverCmdlet : PSCmdlet.PSCmdletPT
    {
        [Parameter]
        public SwitchParameter ShowBrowser { get; set; }


        public UpdateChromeDriverCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            GetChromeDriver.ChromeDriver.DownloadLatestVersion();
            base.ProcessRecord();
        }
    }
}
