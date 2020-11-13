using ProductivityTools.Bank.Inteligo.Cmdlet.LoginToInteligo.Commands;
using System;
using System.Management.Automation;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.LoginToInteligo
{
    [Cmdlet("Login", "ToInteligo")]
    public class LoginToInteligoCmdlet : PSCmdlet.PSCmdletPT
    {
        [Parameter]
        public SwitchParameter ShowBrowser { get; set; }


        public LoginToInteligoCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            this.AddCommand(new Login(this));
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
