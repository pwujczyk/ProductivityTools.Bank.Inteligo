using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.GetBasicData.Commands
{
    class Get : InteligoCommandBase<GetBasicDataCmdlet>
    {
        public Get(GetBasicDataCmdlet cmdletType) : base(cmdletType)
        {
        }

        protected override bool Condition => true;

        protected override void Invoke()
        {
            this.InteligoApplication.GetBasicData(this.Login, this.Password);
        }
    }
}
