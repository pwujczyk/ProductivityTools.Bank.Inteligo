using ProductivityTools.Bank.Inteligo.Cmdlet.LoginToInteligo.Commands;
using System;
using System.Management.Automation;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.LoginToInteligo
{
    [Cmdlet("Login", "ToInteligo")]
    public class LoginToInteligoCmdlet : PSCmdlet.PSCmdletPT
    {
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
