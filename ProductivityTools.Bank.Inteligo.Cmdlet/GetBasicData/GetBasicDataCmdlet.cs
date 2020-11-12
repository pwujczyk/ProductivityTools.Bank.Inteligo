using ProductivityTools.Bank.Inteligo.Cmdlet.GetBasicData.Commands;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.GetBasicData
{ 
    [Cmdlet(VerbsCommon.Get, "InteligoBasicData")]
    public class GetBasicDataCmdlet : PSCmdlet.PSCmdletPT
    {
        public GetBasicDataCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            this.AddCommand(new Get(this));
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
